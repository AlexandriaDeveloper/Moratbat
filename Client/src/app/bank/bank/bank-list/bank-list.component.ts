import { Router } from '@angular/router';
import { SearchData, TableComponent, sortData } from 'src/app/shared/components/table/table.component';
import { BankService } from './../../../shared/services/features/bank.service';
import { Component, Inject, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MatTableConfigs } from 'src/app/shared/components/table/table-configs/mat-table-config';
import { BankParam } from 'src/app/shared/models/param';
import { MatDialog } from '@angular/material/dialog';
import { AddBankDialogComponent } from '../add-bank-dialog/add-bank-dialog.component';
import { Bank } from 'src/app/shared/models/bank';
import { ResponseObject } from 'src/app/shared/models/ResponseObject';
import { DeleteDialogComponent } from 'src/app/shared/components/layout/delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-bank-list',
  templateUrl: './bank-list.component.html',
  styleUrls: ['./bank-list.component.scss']
})
export class BankListComponent implements OnInit, AfterViewInit {
  displayedColumns: MatTableConfigs = {
    editable :  {
      edit:false,
      select : true,
      delete :true
    },
    columnHeader: [
    {
      value: 'name',
      text: 'اسم البنك',
      search: true,
      sort:false
    },
    {
      value:'branchesCount',
      text:'عدد الفروع',
    }

    ]
  }
  @ViewChild('myTable',{static:false}) table :TableComponent;
data:ResponseObject<Bank>;
param : BankParam ;
constructor(private bankService: BankService, private router : Router,public dialog: MatDialog) {

}
ngOnInit(): void {
this.param= new BankParam();

}
loadData(){
  this.bankService.getBanks(this.param).subscribe(x => {
    console.log(x);
    this.data=x
    this.table.data=x.value;
    this.table.loadData(x.value)
  });
}
ngAfterViewInit(): void {
  this.table.displayedColumns=this.displayedColumns;
  this.loadData();
}
openAddBankDialog(){
  let dialogRef = this.dialog.open(AddBankDialogComponent, {
    width: '450px',
    disableClose: true,
    panelClass:['dialog']
  });

  dialogRef.afterClosed().subscribe(result => {
    this.loadData();
    //this.animal = result;
  });

}
pageChange(ev){
  this.param.pageIndex=++ev.pageIndex;
  this.param.pageSize=ev.pageSize;
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
this.router.navigateByUrl('bank/bank-list/'+ev)
console.log(ev);
}

onDelete(ev:any){

  let dialogRef = this.dialog.open(DeleteDialogComponent, {
    width: '550px',
    disableClose: true,
    data:{title:'حذف بنك',message:`انت على وشك حذف ${ev.name} هل انت متأكد ؟؟!`},

  });

  dialogRef.afterClosed().subscribe(result => {
    if(result){
      this.bankService.deleteBank(ev.id).subscribe(x=>{
        this.loadData();
      })

    }
  });
}
}
