import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Subscription } from 'rxjs';
import { Status } from 'src/app/shared/codebook/status.model';
import { ButtonAction } from 'src/app/shared/edit-button/button-action';
import { AppState } from 'src/app/store/app.reducer';
import { Priority } from '../../shared/codebook/priority.model';
import { Task } from './task.model';

import * as fromBoardsActions from '../../boards/store/board.actions';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css'],
})
export class TaskComponent implements OnInit, OnDestroy {
  public mode: FormMode = FormMode.View;
  public taskForm: FormGroup;
  @Input() public task: Task;
  public editActions: Array<ButtonAction> = [];
  public statusList: Array<Status> = [];
  public priorityList: Array<Priority> = [];
  public storeSubscription: Subscription;
  constructor(private store: Store<AppState>) {}

  ngOnInit(): void {
    console.log(this.task);
    this.initTaskForm();
    this.storeSubscription = this.store
      .select('codebooks')
      .subscribe((state) => {
        this.statusList = state.statuses;
        this.priorityList = state.priorities;
      });

    this.editActions.push(
      {
        actionName: 'Edit',
        icon: 'bi bi-pencil',
      },
      {
        actionName: 'Delete',
        icon: 'bi bi-trash',
      }
    );
  }

  ngOnDestroy(): void {
    this.storeSubscription?.unsubscribe();
  }

  onEdit() {
    this.mode = FormMode.Edit;
  }

  currentTime() {
    return new Date(new Date().getTime());
  }

  onChangesSubmit() {
    console.log(this.task);
    console.log(this.taskForm.value);
    let updatedTask = this.taskForm.value as Task;
    updatedTask.boardId = this.task.boardId;
    updatedTask.taskId = this.task.taskId;
    this.store.dispatch(new fromBoardsActions.UpdateTask(updatedTask));
  }

  get controls() {
    return (<FormArray>this.taskForm.get('taskChecklists')).controls;
  }

  addCheckItem() {
    (<FormArray>this.taskForm.get('taskChecklists')).push(
      new FormGroup({
        name: new FormControl('', Validators.required),
        checked: new FormControl(false),
      })
    );
    this.mode = FormMode.Edit;
  }

  removeCheck(index: number) {
    (<FormArray>this.taskForm.get('taskChecklists')).removeAt(index);
    if (this.mode == FormMode.View) {
      this.mode = FormMode.Edit;
    }
  }

  onActionButtonClicked(actionName: string) {
    switch (actionName) {
      case 'Edit':
        this.onEdit();
        return;
      default:
        return;
    }
  }

  onCancel() {
    this.initTaskForm();
    this.mode = FormMode.View;
  }

  get priority(): Priority | undefined {
    let p = this.priorityList.find(
      (item) => item.priorityId == this.taskForm.get('priorityId')?.value
    );
    return p;
  }

  get status(): Status | undefined {
    return this.statusList.find(
      (item) => item.statusId == this.taskForm.get('statusId')?.value
    );
  }

  onCheckChange(index: number, event: any) {
    console.log(event.target.checked);
    let check = this.task.taskChecklists[index];
    this.store.dispatch(
      new fromBoardsActions.CheckUpdate({
        boardId: this.task.boardId,
        checked: event.target.checked,
        taskChecklistId: check.taskChecklistId,
        taskId: this.task.taskId,
      })
    );
  }

  private initTaskForm() {
    let taskChecklists = new FormArray([]);

    this.task?.taskChecklists?.forEach((item) => {
      taskChecklists.push(
        new FormGroup({
          name: new FormControl(item.name, Validators.required),
          checked: new FormControl(item.checked),
          taskChecklistId: new FormControl(item.taskChecklistId),
          taskId: new FormControl(item.taskId),
        })
      );
    });

    this.taskForm = new FormGroup({
      statusId: new FormControl(this.task.statusId, Validators.required),
      priorityId: new FormControl(this.task.priorityId, Validators.required),
      name: new FormControl(this.task.name, Validators.required),
      description: new FormControl(this.task.description, Validators.required),
      startDateTime: new FormControl(this.task.startDateTime),
      dueDate: new FormControl(this.task.dueDate),
      endDate: new FormControl(this.task.endDate),
      attachmentLink: new FormControl(
        this.task.attachmentLink,
        Validators.maxLength(2048)
      ),
      note: new FormControl(this.task.note, Validators.maxLength(100)),
      timeAmount: new FormControl(this.task.timeAmount),
      taskChecklists: taskChecklists,
    });
  }
}

export enum FormMode {
  Add,
  Edit,
  View,
}
