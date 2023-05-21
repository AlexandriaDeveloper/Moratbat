import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { sortData } from '../table.component';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-sort-btn',
  templateUrl: './sort-btn.component.html',
  styleUrls: ['./sort-btn.component.scss'],

})
export default class SortBtnComponent implements OnInit, OnChanges , AfterViewInit {
  ngOnInit(): void {
   // throw new Error('Method not implemented.');
  }
  ngAfterViewInit(): void {
    this.current=''
    console.log(this.elementName)
  }
  ngOnChanges(changes: SimpleChanges): void {
    this.current=''
  }
iconName :string='sort_by_alpha';
sortDirection;
@Input('element') elementName:string;
@Output('sortEvent') sortEventEmitter: EventEmitter< sortData >=new EventEmitter<sortData>();

// Define an object with 3 keys and values
 toggleObj = {
  "": "asc",
  "asc": "desc",
  "desc": ""
};

// Define a variable to hold the current string
 current = "";

sortData(ev){
this.current= this.toggleObj[ev.direction];
ev.direction = this.current;
if(this.current==='')
{
 this.iconName='sort_by_alpha'
}
if(this.current==='asc')
{
 this.iconName='arrow_upward'
}
if(this.current==='desc')
{
 this.iconName='arrow_downward'
}
this.sortEventEmitter.emit(ev);
  }

  reset(){
    this.iconName='sort_by_alpha';
    this.current='';
 //  this.sortData({active:this.elementName,direction:''})
  }
}

