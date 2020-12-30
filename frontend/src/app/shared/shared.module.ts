import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AreaComponent } from './widgets/area/area.component';
import { ColumnComponent } from './widgets/column/column.component';
import { DatepickerComponent } from './widgets/datepicker/datepicker.component';



@NgModule({
  declarations: [AreaComponent, ColumnComponent, DatepickerComponent],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
