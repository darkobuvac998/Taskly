import { Component, HostListener, Input, OnInit } from '@angular/core';
import { ButtonAction } from 'src/app/shared/edit-button/button-action';
import { pinBoard } from '../animations';
import { BoardCard } from './board-card.model';

@Component({
  selector: 'app-board-card',
  templateUrl: './board-card.component.html',
  styleUrls: ['./board-card.component.css'],
  animations: [pinBoard],
})
export class BoardCardComponent implements OnInit {
  @Input() public board: BoardCard;
  public actions: Array<ButtonAction> = [];

  ngOnInit(): void {
    this.actions.push(
      {
        actionName: 'Archive',
        icon: 'bi bi-archive',
      },
      {
        actionName: 'show',
        icon: 'bi bi-eye',
      }
    );
  }

  onPinBoard() {
    console.log(this.board.pinned);
    this.board.pinned = !this.board.pinned;
  }
}
