import { Component, OnInit } from '@angular/core';
import { Sale } from 'src/app/models/sale.class';
import { RevenueService } from 'src/app/services/revenue.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  sales!: Sale[];

  loading = true;
  
  constructor(private revenueService: RevenueService) { }

  ngOnInit(): void {
  }

  redraw(event: { startDate: string; endDate: string; }) {
    this.loading = true;
    this.revenueService.getRevenue(event.startDate, event.endDate).subscribe(response =>
      {
        this.sales = response;
        this.loading = false;
        console.log(response);
      });
  }

}
