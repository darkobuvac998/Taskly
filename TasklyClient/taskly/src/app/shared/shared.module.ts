import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { EditButtonComponent } from './edit-button/edit-button.component';
import { ToolbarComponent } from './toolbar/toolbar.component';

@NgModule({
  declarations: [ToolbarComponent, EditButtonComponent],
  imports: [CommonModule],
  exports: [ToolbarComponent, EditButtonComponent],
})
export class SharedModule {}
