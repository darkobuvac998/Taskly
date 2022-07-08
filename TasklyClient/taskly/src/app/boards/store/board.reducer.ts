import { Action } from '@ngrx/store';
import { BoardCard } from '../board-card/board-card.model';
import { BoardsAction } from './board.actions';

import * as fromBoardsActions from './board.actions';
import { Task } from 'src/app/tasks/task/task.model';
import { TaskCheck } from 'src/app/tasks/task-checklist/task-checklist.model';

export interface BoardStore {
  boards: Array<BoardCard>;
}

const initialState: BoardStore = {
  boards: [],
};

export function boardsReducer(
  state = initialState,
  action: BoardsAction
): BoardStore {
  let payload: any = action.payload;
  let board: BoardCard;
  let task: Task;
  let check: TaskCheck;
  let updatedTask: Task;
  let updatedChecklists: TaskCheck[];
  let updatedTasks: Task[];
  let taskIndex: number;
  let updatedBoard: BoardCard;
  switch (action.type) {
    case fromBoardsActions.SET_BOARDS:
      return {
        ...state,
        boards: payload,
      };
    case fromBoardsActions.UPDATE_TASK:
      board = state.boards.find(
        (item) => item.boardId == payload.boardId
      ) as BoardCard;
      task = board.tasks.find((item) => item.taskId == payload.taskId) as Task;
      updatedTask = {
        ...task,
        ...payload,
        taskChecklists: [...payload.taskChecklists],
      };
      console.log(updatedTask);
      taskIndex = board.tasks.findIndex((item) => item.taskId == task.taskId);
      updatedTasks = [...board.tasks];
      if (taskIndex > -1) {
        updatedTasks[taskIndex] = updatedTask;
      }
      updatedBoard = {
        ...board,
        tasks: updatedTasks,
      } as BoardCard;
      const boardIndex = state.boards.findIndex(
        (item) => item.boardId == payload.boardId
      );
      const updatedBoards = [...state.boards];
      if (boardIndex > -1) {
        updatedBoards[boardIndex] = updatedBoard;
      }

      return {
        ...state,
        boards: updatedBoards,
      };
    case fromBoardsActions.CHECK_UPDATE:
      board = state.boards.find(
        (item) => item.boardId == payload.boardId
      ) as BoardCard;
      task = board.tasks.find((item) => item.taskId == payload.taskId) as Task;
      const updatedCheck = {
        ...(task.taskChecklists.find(
          (item) => item.taskChecklistId == payload.taskChecklistId
        ) as TaskCheck),
        checked: payload.checked,
      };

      const checkIndex = task.taskChecklists.findIndex(
        (item) => item.taskChecklistId == payload.taskChecklistId
      );

      updatedChecklists = [...task.taskChecklists];
      if (checkIndex > -1) {
        updatedChecklists[checkIndex] = updatedCheck;
      }

      updatedTask = {
        ...task,
        taskChecklists: updatedChecklists,
      };

      updatedTasks = [...board.tasks];

      taskIndex = updatedTasks.findIndex(
        (item) => item.taskId == payload.taskId
      );

      if (taskIndex > -1) {
        updatedTasks[taskIndex] = updatedTask;
      }

      updatedBoard = {
        ...board,
        tasks: updatedTasks,
      };

      const bi = state.boards.findIndex(
        (item) => item.boardId == updatedBoard.boardId
      );

      const upbds = [...state.boards];

      if (bi > -1) {
        upbds[bi] = updatedBoard;
      }

      return {
        ...state,
        boards: upbds,
      };

    default:
      return state;
  }
}

const updateTask = (old: Task, newTask: Task, ...args: []) => {
  let result = {};
  args.forEach((item) => {
    result = { ...result, item };
  });
  return {
    ...old,
    ...newTask,
    ...result,
  };
};
