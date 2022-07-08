import { Priority } from '../priority.model';
import { Status } from '../status.model';
import { CodebooksActions } from './codebook.actions';

import * as fromCodebooks from './codebook.actions';

export interface CodebooksStore {
  statuses: Status[];
  priorities: Priority[];
}
const initialState: CodebooksStore = {
  priorities: [],
  statuses: [],
};
export function codebooksReducer(
  state = initialState,
  action: CodebooksActions
): CodebooksStore {
  let payload: any = action.payload;
  switch (action.type) {
    case fromCodebooks.SET_STATUSES:
      return {
        ...state,
        statuses: payload,
      };
    case fromCodebooks.SET_PRIORITIES:
      return {
        ...state,
        priorities: payload,
      };
    default:
      return state;
  }
}
