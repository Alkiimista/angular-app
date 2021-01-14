import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment'

@Component({
  selector: 'app-widget-datepicker',
  templateUrl: './datepicker.component.html',
  styleUrls: ['./datepicker.component.scss']
})
export class DatepickerComponent implements OnInit {

  @Output() dateChanged: EventEmitter<any> = new EventEmitter();

  range!: FormGroup;

  startDate!: string;
  endDate!: string;

  constructor() { }

  ngOnInit(): void {
    this.range = new FormGroup({
      start: new FormControl(
        null,
        [
          Validators.required
        ]
      ),
      end: new FormControl(
        null,
        [
          Validators.required
        ]
      )
    });
  }

  onFormSubmit() {
    if(!this.range.invalid) {
      this.startDate = moment(this.range.value.start).format("YYYY-MM-DD");
      this.endDate = moment(this.range.value.end).format("YYYY-MM-DD");

      console.log(this.startDate);
      console.log(this.endDate);
      
      this.dateChanged.emit({
        startDate: this.startDate,
        endDate: this.endDate
      })
    }
  }

}
