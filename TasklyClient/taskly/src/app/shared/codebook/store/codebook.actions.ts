import { BaseAction } from 'src/app/store/base-action';
import { Priority } from '../priority.model';
import { Status } from '../status.model';

export const FETCH_STATUSES = '[Codebooks] Fetch Statuses';
export const FETCH_PRIORITIES = '[Codebooks] Fetch Priorities';
export const SET_STATUSES = '[Codebooks] Set Statuses';
export const SET_PRIORITIES = '[Codebooks] Set Priorities';

export class FetchStatuses extends BaseAction<null> {
  type: string = FETCH_STATUSES;
}

export class SetStatuses extends BaseAction<Status[]> {
  type: string = SET_STATUSES;
}

export class FetchPriorities extends BaseAction<null> {
  type: string = FETCH_PRIORITIES;
}

export class SetPriorities extends BaseAction<Priority[]> {
  type: string = SET_PRIORITIES;
}

export type CodebooksActions =
  | FetchPriorities
  | FetchStatuses
  | SetStatuses
  | SetPriorities;
