import { BaseAction } from 'src/app/store/base-action';
import { BoardCard } from '../board-card/board-card.model';
import { Task } from 'src/app/tasks/task/task.model';

export const ADD_TASK = '[Boards] Add Task';
export const UPDATE_TASK = '[Boards] Update Task';
export const DELETE_TASK = '[Boards] Delete Task';
export const ON_EDIT_CANCEL = '[Boards] Cancel Edit';
export const CHECK_UPDATE = '[Boards] Check Update';

export const ADD_BOARD = '[Boards] Add Board';
export const UPDATE_BOARD = '[Boards] Update Board';
export const DELETE_BOARD = '[Boards] Delete Board';
export const ARCHIVE_BOARD = '[Boards] Archive Board';
export const FETCH_BOARDS = '[Boards] Fetch Boards';
export const SET_BOARDS = '[Boards] Set Boards';

export class AddTask extends BaseAction<Task> {
  override readonly type: string = ADD_TASK;
}
export class UpdateTask extends BaseAction<Task> {
  override readonly type: string = UPDATE_TASK;
}
export class DeleteTask extends BaseAction<{
  boardId: number;
  taskId: number;
}> {
  override readonly type: string = DELETE_TASK;
}

export class SetBoards extends BaseAction<BoardCard[]> {
  type: string = SET_BOARDS;
}

export class FetchBoards extends BaseAction<null> {
  type: string = FETCH_BOARDS;
}

export class OnEditCancel extends BaseAction<null> {
  type: string = ON_EDIT_CANCEL;
}

export class CheckUpdate extends BaseAction<{
  boardId: number;
  taskId: number;
  taskChecklistId: number;
  checked: boolean;
}> {
  type: string = CHECK_UPDATE;
}

export type BoardsAction =
  | AddTask
  | UpdateTask
  | DeleteTask
  | SetBoards
  | FetchBoards
  | OnEditCancel;
