
import { Component, ViewChild, ElementRef, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'search-box-dates',
  templateUrl: './search-box-dates.component.html',
  styleUrls: ['./search-box-dates.component.scss']
})
export class SearchBoxDatesComponent {

 public minDate: Date;
 public maxDate: Date;

  inputSearch: string;
  inputDateStart: Date;
  inputDateEnd: Date;

  @Output()
  searchChange = new EventEmitter<modelSearch>();

  constructor() {
    this.minDate = new Date();
    this.maxDate = new Date();
    this.minDate.setDate(this.maxDate.getDate() - 120);
    this.maxDate.setDate(this.maxDate.getDate() );
  }

  onValueChangeSearch(value: string) {
    this.inputSearch = value;
    let savParamters: modelSearch = { search: this.inputSearch, dateStart: this.inputDateStart, dateEnd: this.inputDateEnd };
    setTimeout(() => this.searchChange.emit(savParamters));
  }

  onValueChangeDateStart(value: Date) {
    this.inputDateStart = value;
    let savParamters: modelSearch = { search: this.inputSearch, dateStart: this.inputDateStart, dateEnd: this.inputDateEnd };
    setTimeout(() => this.searchChange.emit(savParamters));
  }

  onValueChangeDateEnd(value: Date) {
    this.inputDateEnd = value;
    let savParamters: modelSearch = { search: this.inputSearch, dateStart: this.inputDateStart, dateEnd: this.inputDateEnd };
    setTimeout(() => this.searchChange.emit(savParamters));
  }

}

export interface modelSearch {
  search: string,
  dateStart: Date,
  dateEnd: Date
}
