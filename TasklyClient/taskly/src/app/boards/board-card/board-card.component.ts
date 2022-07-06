import { Component, HostListener, Input } from '@angular/core';
import { pinBoard } from '../animations';
import { BoardCard } from './board-card.model';

@Component({
  selector: 'app-board-card',
  templateUrl: './board-card.component.html',
  styleUrls: ['./board-card.component.css'],
  animations: [pinBoard],
})
export class BoardCardComponent {
  @Input() public board: BoardCard;

  onPinBoard() {
    this.board.pinned = !this.board.pinned;
  }
}
