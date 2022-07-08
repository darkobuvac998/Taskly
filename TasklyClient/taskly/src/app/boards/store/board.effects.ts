import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, switchMap } from 'rxjs/operators';
import { BoardCard } from '../board-card/board-card.model';

import * as BoardsActions from './board.actions';

@Injectable()
export class BoardEffects {
  fetchBoards$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(BoardsActions.FETCH_BOARDS),
      switchMap((_) => {
        return this.http.get<BoardCard[]>(`https://localhost:7166/api/Board`);
      }),
      map((boards) => {
        return boards.map((item) => {
          return {
            ...item,
            tasks: item.tasks ? item.tasks : [],
          };
        });
      }),
      map((boards) => {
        return new BoardsActions.SetBoards(boards);
      })
    );
  });

  constructor(private actions$: Actions, private http: HttpClient) {}
}
