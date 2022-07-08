import { ActionReducerMap } from '@ngrx/store';
import * as fromBoards from '../boards/store/board.reducer';
import * as fromCodebooks from '../shared/codebook/store/codebook.reducer';

export interface AppState {
  boards: fromBoards.BoardStore;
  codebooks: fromCodebooks.CodebooksStore;
}

export const appReducer: ActionReducerMap<AppState> = {
  boards: fromBoards.boardsReducer,
  codebooks: fromCodebooks.codebooksReducer,
};
