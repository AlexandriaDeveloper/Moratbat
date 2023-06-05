import {  MatTableConfigs } from 'src/app/shared/components/table/table-configs/mat-table-config';
import { EmployeeService } from '../../shared/services/features/employee.service';
import { Component, AfterViewInit, ViewChild, ViewEncapsulation, OnInit } from '@angular/core';
import { EmployeeParam } from 'src/app/shared/models/param';
import { SearchData, TableComponent, sortData } from 'src/app/shared/components/table/table.component';
import { Router } from '@angular/router';



@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
  encapsulation:ViewEncapsulation.None,

})
export class EmployeeListComponent implements  OnInit, AfterViewInit {
displayedColumns: MatTableConfigs = {
  editable :  {
    edit:false,
    select : true,
    delete :false
  },
  columnHeader: [
  {
    value: 'tabCode',
    text: 'كود طب',
    search: true,
    sort:true
  },

  {
    value: 'tegaraCode',
    text: 'كود تجارة',
     search: true,
     sort:true
  },
  {
    value: 'name',
    text: 'الاسم',
      search: true,
      sort:true
  },
  {
    value: 'nationalId',
    text: 'الرقم القومى',
      search: true,
      sort:true
  }

  ]
}
param :EmployeeParam;
  //'id' ,'name','tabCode','tegaraCode','nationalId';
  @ViewChild('myTable',{static:false}) table :TableComponent;
data;


constructor(private employeeService :EmployeeService, private router : Router){}
  ngOnInit(): void {
  this.param= new EmployeeParam();
  }

  loadData (){
 this.employeeService.getEmployees(this.param)
 .subscribe((x:any) => {
  console.log(x);
   this.data=x
   this.table.data=x.value
   this.table.loadData(x.value)
   });

    };


  pageChange(ev){
    this.param.pageIndex=++ev.pageIndex;
    this.param.pageSize=ev.pageSize;
    this.loadData();
  }
  ngAfterViewInit() {


      this.table.displayedColumns=this.displayedColumns;
      this.loadData();

  }
onSearch(event :SearchData ){
       // console.log(event);
        this.param[event.elementName]=event.value;
        this.loadData();

}
onSortChange(ev:sortData){
  this.param.active =ev.active;
  this.param.direction=ev.direction;
  this.loadData();
}
onSelect(ev){
this.router.navigateByUrl('employee/details/'+ev)
}


}


