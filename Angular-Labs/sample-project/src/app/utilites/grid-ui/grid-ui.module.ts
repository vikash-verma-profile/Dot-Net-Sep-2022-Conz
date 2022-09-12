import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GridUiComponent } from './grid-ui.component';

@NgModule({
  declarations: [
    GridUiComponent
  ],
  imports: [CommonModule],
  exports:[GridUiComponent,CommonModule]
})
export class GridUIModule { }
