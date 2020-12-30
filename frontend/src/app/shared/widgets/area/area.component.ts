import { Component, Input, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import * as moment from 'moment';
import { Sale } from 'src/app/models/sale.class';

@Component({
  selector: 'app-widget-area',
  templateUrl: './area.component.html',
  styleUrls: ['./area.component.scss']
})
export class AreaComponent implements OnInit {

  @Input() sales!: Sale[];
  
  Highcharts = Highcharts;
  chartOptions!: {};
  
  constructor() { }

  ngOnInit(): void {
    this.chartOptions = {
      chart: {
          type: 'area'
      },
      title: {
          text: 'Daily Revenue'
      },
      subtitle: {
          text: 'Demo'
      },
      credits: {
        enabled: false
      },
      xAxis: {
      },
      plotOptions: {
          area: {
              stacking: 'normal',
              lineColor: '#666666',
              lineWidth: 1,
              marker: {
                  lineWidth: 1,
                  lineColor: '#666666'
              }
          },
          series: {
            turboThreshold: 10000
          }
      },
      series: this.appoint(this.sales)
    };

    setTimeout(() => {
      window.dispatchEvent(
        new Event('resize')
      );
    }, 300);
    
    
  }

  appoint(mapData: any) {
    const newArray = [];

    for (const data of mapData) {
        // check if there are existing items in the array.
        const index = newArray.findIndex(object => object.name === data.product);
        if (index > -1) {
            newArray[index].data.push([
                moment(data.date).format("YYYY-MM-DD"),
                data.price
            ]);
        } else {
            newArray.push({
                name: data.product,
                data: [[
                    moment(data.date).format("YYYY-MM-DD"),
                    data.price
                ]
              ]
            });
        }
    }
    return newArray;
  }

}
