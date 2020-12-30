import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DefaultComponent } from './default.component';
import { DashboardComponent } from 'src/app/modules/dashboard/dashboard.component';
import { AboutComponent } from 'src/app/modules/about/about.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';

import { MatSidenavModule} from '@angular/material/sidenav';
import { MatDividerModule} from '@angular/material/divider';
import { MatCardModule } from '@angular/material/card';

import { FlexLayoutModule } from '@angular/flex-layout';

import { HttpClientModule } from '@angular/common/http'
import { RevenueService } from 'src/app/services/revenue.service';



@NgModule({
  declarations: [
    DefaultComponent,
    DashboardComponent,
    AboutComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    MatSidenavModule,
    MatDividerModule,
    MatCardModule,
    FlexLayoutModule,
    HttpClientModule
  ],
  providers: [
    RevenueService
  ]
})
export class DefaultModule { }
