
import { Component, ViewChild, ElementRef, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'search-box-dates',
  templateUrl: './search-box-dates.component.html',
  styleUrls: ['./search-box-dates.component.scss']
})
export class SearchBoxDatesComponent {

  @Input()
  placeholder = 'Buscar...';

  @Output()
  searchChange = new EventEmitter<string>();

  @ViewChild('searchInput', { static: true })
  searchInput: ElementRef;

  @ViewChild('searchInputStart', { static: true })
  searchInputStart: ElementRef;

  @ViewChild('searchInputEnd', { static: true })
  searchInputEnd: ElementRef;


  onValueChange(value: string) {
      setTimeout(() => this.searchChange.emit(value));
  }


  clear() {
      this.searchInput.nativeElement.value = '';
      this.onValueChange(this.searchInput.nativeElement.value);
  }
}
