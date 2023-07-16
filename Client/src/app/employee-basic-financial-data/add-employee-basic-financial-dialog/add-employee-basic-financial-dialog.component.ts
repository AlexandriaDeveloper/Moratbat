import { Component, Inject, AfterViewInit, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as moment from 'moment';
import { AddBankDialogComponent } from 'src/app/bank/bank/add-bank-dialog/add-bank-dialog.component';
import { IAccountTree } from 'src/app/shared/models/IAccountTree';
import { AccountsTreeService } from 'src/app/shared/services/features/accounts-tree.service';
import { EmployeeBasicFinancialDataService } from 'src/app/shared/services/features/employee-basic-financial-data.service';

@Component({
  selector: 'app-add-employee-basic-financial-dialog',
  templateUrl: './add-employee-basic-financial-dialog.component.html',
  styleUrls: ['./add-employee-basic-financial-dialog.component.scss']
})
export class AddEmployeeBasicFinancialDialogComponent implements OnInit  , AfterViewInit{
  accountTreeObj : IAccountTree;
  parentBudgetItems:any;
  childAccountTrees:any;
  subChildAccountTrees:any;
  subSubChildAccountTree:any;
  subSubChildAccountTreeDetails:any;
  form : FormGroup;
  financialSource =[{id:0,name:'تمويل ذاتى'},{id:1,name:'موازنه'}];
  constructor(public dialogRef: MatDialogRef<AddBankDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,private accountsTreeService: AccountsTreeService ,private employeeBasicFinancialData : EmployeeBasicFinancialDataService) {}
    ngOnInit(): void {
      this.parentBudgetItems=null;
      this.accountsTreeService.getParentsBudgetItems().subscribe(x => this.parentBudgetItems=x);
      this.form=this.intilizeForm();
    }
    ngAfterViewInit(): void {
console.log(this.data);

    }
    getAccountChildData(ev){
    this.childAccountTrees=null;

      this.accountsTreeService.getChildrenBudgetItems(ev.value).subscribe(x =>
        this.childAccountTrees=x

        );
    }
    getAccountSubChildData(ev){
      this.subChildAccountTrees=null;

      console.log(ev);

      this.accountsTreeService.getChildrenBudgetItems(ev.value).subscribe(x =>
        this.subChildAccountTrees=x
        );
    }
    getAccountSubSubChildData(ev){
      console.log(ev);

      this.subSubChildAccountTree=null;
      this.form.patchValue({'accountTreeDetailsAccountTreeId':ev.value})

      this.accountsTreeService.getChildrensAccountsTreeData(ev.value).subscribe(x =>
        {
          console.log(x);

        this.subSubChildAccountTree=x
      }
        );
    }

    getAccountSubSub2ChildData(ev){

      this.form.patchValue({'accountTreeDetailsId':ev.value})
    }
    getfinancialSource(ev){

      this.form.patchValue({'financialSource':ev.value})

    }
      intilizeForm (){
        return this.fb.group({
          employeeId:[this.data.employeeId,Validators.required],
          financialSource :['',Validators.required],
          startDate :['',Validators.required],
          accountTreeDetailsAccountTreeId:['',Validators.required],
          accountTreeDetailsId:['',Validators.required],
          amount :['',Validators.required],
        })
      }
    onNoClick(){
      this.dialogRef.close(false);
    }
    changeDate(ev){
      this.form.patchValue({startDate : moment( ev.value).format()})
    }
    onSubmit(){
      this.employeeBasicFinancialData.addToEmployeeBasicFinancialData(this.form.value).subscribe(x=>{
        this.dialogRef.close(true);
      })
    }
}
