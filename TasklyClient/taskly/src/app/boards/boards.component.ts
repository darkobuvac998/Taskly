import { Component, OnInit } from '@angular/core';
import { BoardCard } from './board-card/board-card.model';

@Component({
  selector: 'app-boards',
  templateUrl: './boards.component.html',
  styleUrls: ['./boards.component.css'],
})
export class BoardsComponent implements OnInit {
  public boards: Array<BoardCard> = [];

  constructor() {}

  ngOnInit(): void {
    this.boards.push(new BoardCard());
    this.boards.push(new BoardCard());
    this.boards.push(new BoardCard());
  }
}
