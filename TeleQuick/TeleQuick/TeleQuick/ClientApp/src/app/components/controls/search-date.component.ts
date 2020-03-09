
import { Component, ViewChild, ElementRef, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'search-date',
    templateUrl: './search-date.component.html',
    styleUrls: ['./search-date.component.scss']
})
export class SearchDateComponent {

    @Input()
    placeholder = 'Buscar...';

    @Output()
    searchChange = new EventEmitter<string>();

    @ViewChild('searchInputDate', { static: true })
    searchInput: ElementRef;


    onValueChange(value: string) {
        setTimeout(() => this.searchChange.emit(value));
    }


    clear() {
        this.searchInput.nativeElement.value = '';
        this.onValueChange(this.searchInput.nativeElement.value);
    }
}
