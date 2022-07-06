import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ButtonAction } from 'src/app/shared/edit-button/button-action';
import { Priority } from '../priority.model';
import { Status } from '../status.model';
import { Task } from './task.model';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css'],
})
export class TaskComponent implements OnInit {
  public mode: FormMode = FormMode.View;
  public taskForm: FormGroup;
  public task: Task;
  public editActions: Array<ButtonAction> = [];
  public statusList: Array<Status> = [];
  public priorityList: Array<Priority> = [];
  constructor() {}

  ngOnInit(): void {
    this.initTaskForm();

    this.priorityList.push(
      {
        priorityId: 1,
        name: 'Low',
        color: '#FFEA00',
      },
      {
        priorityId: 2,
        name: 'Medium',
        color: '#FF3131',
      }
    );

    this.statusList.push(
      {
        statusId: 1,
        name: 'Finished',
        color: '#32CD32',
      },
      {
        statusId: 1,
        name: 'In Progress',
        color: '#89CFF0',
      }
    );

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

  onEdit() {
    this.mode = FormMode.Edit;
  }

  currentTime() {
    return new Date(new Date().getTime());
  }

  onChangesSubmit() {
    console.log(this.taskForm);
  }

  get controls() {
    return (<FormArray>this.taskForm.get('taskCheckLists')).controls;
  }

  addCheckItem() {
    (<FormArray>this.taskForm.get('taskCheckLists')).push(
      new FormGroup({
        name: new FormControl('', Validators.required),
        checked: new FormControl(false),
      })
    );
    this.mode = FormMode.Edit;
  }

  removeCheck(index: number) {
    (<FormArray>this.taskForm.get('taskCheckLists')).removeAt(index);
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
    let ctl = this.controls;
    ctl = ctl.filter((item) => item.valid);
    let newCtl = new FormArray([...ctl]);
    this.taskForm.setControl('taskCheckLists', newCtl);
    this.mode = FormMode.View;
  }

  private initTaskForm() {
    let taskCheckLists = new FormArray([]);
    taskCheckLists.push(
      new FormGroup({
        name: new FormControl('Check 1', Validators.required),
        checked: new FormControl(true),
      })
    );

    this.taskForm = new FormGroup({
      statusId: new FormControl(1, Validators.required),
      priorityId: new FormControl(1, Validators.required),
      name: new FormControl('Test task', Validators.required),
      description: new FormControl(
        `Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.`,
        Validators.required
      ),
      startDateTime: new FormControl(),
      dueDate: new FormControl(),
      endDate: new FormControl(),
      attachmentLink: new FormControl(
        'https://drive.google.com',
        Validators.maxLength(2048)
      ),
      note: new FormControl('Test note', Validators.maxLength(100)),
      timeAmount: new FormControl(''),
      taskCheckLists: taskCheckLists,
    });
  }
}

export enum FormMode {
  Add,
  Edit,
  View,
}
