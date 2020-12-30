import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AreaComponent } from './widgets/area/area.component';
import { ColumnComponent } from './widgets/column/column.component';
import { DatepickerComponent } from './widgets/datepicker/datepicker.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';



@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    AreaComponent, 
    ColumnComponent, 
    DatepickerComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
