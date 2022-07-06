import {
  Component,
  ElementRef,
  EventEmitter,
  HostListener,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { ButtonAction } from './button-action';

@Component({
  selector: 'app-edit-button',
  templateUrl: './edit-button.component.html',
  styleUrls: ['./edit-button.component.css'],
})
export class EditButtonComponent implements OnInit {
  @Input() actions: Array<ButtonAction> = [];
  @Output() onClick: EventEmitter<string> = new EventEmitter<string>();
  public inside: boolean = false;

  public showActions: boolean = false;

  constructor(private elementRef: ElementRef) {}

  ngOnInit(): void {}

  onShowActions() {
    if (this.inside) {
      this.showActions = !this.showActions;
    }
  }

  onActionClicked(actionName: string) {
    this.onClick.emit(actionName);
  }

  @HostListener('document:click', ['$event'])
  onClickOutside(event: any) {
    if (this.elementRef.nativeElement.contains(event.target)) {
      this.inside = true;
    } else {
      this.inside = false;
    }
  }
}
