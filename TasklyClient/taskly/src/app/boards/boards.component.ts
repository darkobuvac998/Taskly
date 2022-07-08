import { Component, OnInit } from '@angular/core';
import { Actions, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { take } from 'rxjs/operators';
import { AppState } from '../store/app.reducer';
import { BoardCard } from './board-card/board-card.model';

import * as BoardsActions from './store/board.actions';
@Component({
  selector: 'app-boards',
  templateUrl: './boards.component.html',
  styleUrls: ['./boards.component.css'],
})
export class BoardsComponent implements OnInit {
  public boards: Array<BoardCard> = [];

  constructor(private store: Store<AppState>) {}

  ngOnInit(): void {
    this.store.dispatch(new BoardsActions.FetchBoards());
    this.store.select('boards').subscribe((state) => {
      this.boards = state.boards;
    });
  }
}
