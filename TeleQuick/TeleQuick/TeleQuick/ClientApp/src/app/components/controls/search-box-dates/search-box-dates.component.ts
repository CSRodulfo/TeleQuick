
import { Component, ViewChild, ElementRef, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'search-box-dates',
  templateUrl: './search-box-dates.component.html',
  styleUrls: ['./search-box-dates.component.scss']
})
export class SearchBoxDatesComponent {

  @Output()
  searchChange = new EventEmitter<modelSearch>();

  @ViewChild('searchInput', { static: true })
  searchInput: ElementRef;

  @ViewChild('searchInputStart', { static: true })
  searchInputStart: ElementRef;

  @ViewChild('searchInputEnd', { static: true })
  searchInputEnd: ElementRef;

  inputSearch: string;
  inputDateStart: Date;
  inputDateEnd: Date;


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
