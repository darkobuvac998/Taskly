import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, switchMap } from 'rxjs/operators';
import { Priority } from '../priority.model';
import { Status } from '../status.model';

import * as fromCodebooks from './codebook.actions';

@Injectable()
export class CodebooksEffects {
  fetchStatuses$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(fromCodebooks.FETCH_STATUSES),
      switchMap((_) => {
        return this.http.get<Status[]>('https://localhost:7166/api/Status');
      }),
      map((statuses) => {
        return new fromCodebooks.SetStatuses(statuses);
      })
    );
  });

  fetchPriorities$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(fromCodebooks.FETCH_PRIORITIES),
      switchMap((_) => {
        return this.http.get<Priority[]>('https://localhost:7166/api/Priority');
      }),
      map((priorities) => {
        return new fromCodebooks.SetPriorities(priorities);
      })
    );
  });

  constructor(private actions$: Actions, private http: HttpClient) {}
}
