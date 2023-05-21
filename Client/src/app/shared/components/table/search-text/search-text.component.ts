import { Component, EventEmitter, Input, Output, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { debounceTime, distinctUntilChanged, fromEvent, map } from 'rxjs';
import { SearchData } from '../table.component';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-search-text',
  templateUrl: './search-text.component.html',
  styleUrls: ['./search-text.component.scss'],
})
export class SearchTextComponent implements AfterViewInit{
  @ViewChild('searchInput') searchText : ElementRef;
  @Input('text-items') textData:any;
  @Output('textChangeEvent') textChangeEvent = new EventEmitter<SearchData>();
  searchData : SearchData= new SearchData();

  ngAfterViewInit(): void {
   fromEvent(this.searchText.nativeElement,'keyup').pipe(debounceTime(600),distinctUntilChanged()
   ,map((x :any)=>{
      this.searchData.elementName = x.target.id;
   this.searchData.value = x.target.value;
   return this.searchData ;
   })).subscribe(x => this.textChangeEventHandler(x));
  }



  textChangeEventHandler (event){
    this.textChangeEvent.emit(this.searchData);
  }

}
