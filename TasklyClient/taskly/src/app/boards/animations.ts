import {
  animate,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';

export const pinBoard = trigger('pin', [
  state(
    'unpin',
    style({
      transform: 'rotate(0deg)',
    })
  ),
  state(
    'pin',
    style({
      transform: 'rotate(-45deg)',
      color: 'white'
    })
  ),
  transition('unpin <=> pin', [animate(300)]),
]);
