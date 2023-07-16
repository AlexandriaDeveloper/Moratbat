import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { ActivatedRoute } from '@angular/router';
import { DeleteDialogComponent } from 'src/app/shared/components/layout/delete-dialog/delete-dialog.component';
import { MatTableConfigs } from 'src/app/shared/components/table/table-configs/mat-table-config';
import { SearchData, TableComponent, sortData } from 'src/app/shared/components/table/table.component';
import { ResponseObject } from 'src/app/shared/models/ResponseObject';
import { Bank, BankBranch } from 'src/app/shared/models/bank';
import { BankBranchParam, BankParam } from 'src/app/shared/models/param';
import { BankBranchesService } from 'src/app/shared/services/features/bank-branches.service';
import { AddBranchDialogComponent } from '../add-branch-dialog/add-branch-dialog.component';
import { BankService } from 'src/app/shared/services/features/bank.service';

@Component({
  selector: 'app-branch-list',
  templateUrl: './branch-list.component.html',
  styleUrls: ['./branch-list.component.scss']
})
export class BranchListComponent {
  bankId : number;
  param : BankBranchParam = new BankBranchParam();
  displayedColumns: MatTableConfigs = {
    editable :  {
      edit:false,
      select : false,
      delete :true
    },
    columnHeader: [
    {
      value: 'name',
      text: 'اسم الفرع',
      search: true,
      sort:false
    }

    ]
  }
  @ViewChild('myTable',{static:false}) table :TableComponent;
  data:ResponseObject<BankBranch>;
  bank : Bank;

  constructor(private bankService:BankService, private bankBranchesService:BankBranchesService, private router: ActivatedRoute,public dialog: MatDialog) { }
  ngOnInit(): void {
    this.bankId= this.router.snapshot.params['id'];
    this.param.bankId=this.bankId;


    this.bankService.getBank(this.bankId).subscribe((x:any)=>{
      console.log(x);
      this.bank=x;
    })
  }
  ngAfterViewInit(): void {
    this.loadData();
  }
  loadData(){
    this.bankBranchesService.getBanks(this.param).subscribe(x=>{
      console.log(x);
      this.data=x
      this.table.data=x.value;
      this.table.loadData(x.value)
    })

  }
  openAddBankBranchDialog(){
    let dialogRef = this.dialog.open(AddBranchDialogComponent, {
      data:{bank : this.bank},
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
 // this.router.navigateByUrl('bank/bank-list/'+ev)
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
        this.bankBranchesService.deleteBankBranch(ev.id).subscribe(x=>{
          this.loadData();
        })

      }
    });
  }

}
