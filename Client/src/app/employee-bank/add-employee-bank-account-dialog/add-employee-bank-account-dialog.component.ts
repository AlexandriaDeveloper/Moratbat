import { EmployeeBank } from './../../shared/models/bank';
import { Component, Inject, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDatepicker } from '@angular/material/datepicker';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as moment from 'moment';
import { Moment } from 'moment';
import { AddBankDialogComponent } from 'src/app/bank/bank/add-bank-dialog/add-bank-dialog.component';
import { Bank, BankBranch } from 'src/app/shared/models/bank';
import { BankBranchParam } from 'src/app/shared/models/param';
import { BankBranchesService } from 'src/app/shared/services/features/bank-branches.service';
import { BankService } from 'src/app/shared/services/features/bank.service';
import { EmployeeBankService } from 'src/app/shared/services/features/employee-bank.service';

@Component({
  selector: 'app-add-employee-bank-account-dialog',
  templateUrl: './add-employee-bank-account-dialog.component.html',
  styleUrls: ['./add-employee-bank-account-dialog.component.scss']
})
export class AddEmployeeBankAccountDialogComponent {
  form : FormGroup;
  bankListA : Bank[];
  bankListB : Bank[];
  branchesA:BankBranch[];
  branchesB:BankBranch[];
  selectedBranchId=null;

  employeeBank : EmployeeBank;


  constructor(public dialogRef: MatDialogRef<AddBankDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,
    private bankService: BankService,
    private bankBranchService :BankBranchesService,
    private employeeBankService : EmployeeBankService) {}
  ngOnInit(): void {
    console.log(this.data);
    this.employeeBank=this.data.employeeBank;
    this.employeeBank.employeeId=this.data.employeeId;
  this.loadBankBranches('A',this.employeeBank.bankAId);
  this.loadBankBranches('B',this.employeeBank.bankBId);
    this.form=this.intilizeForm();
  }
  ngAfterViewInit(): void {
    this.loadBank();
  }

loadBank(){

  this.bankService.getBankList().subscribe((x:Bank[])=>{
    this.bankListA=x;

    this.bankListB=x;
  })}


loadBankBranches(methodAorB:string,bankId:number){

  this.bankBranchService.getBankBrachesList(bankId).subscribe((x:BankBranch[])=>{
    console.log(x);
    if(methodAorB=='A'){
      this.branchesA=x;
    }
    if(methodAorB=='B'){
      this.branchesB=x;
    }

  })
}
/*{
    "bankAId": 1,
    "bankAName": "البنك العربى الأفريقى",
    "branchAName": "مركز البطاقات",
    "accountANumber": "",
    "bankBId": 1,
    "bankBName": "البنك العربى الأفريقى",
    "branchBName": "مركز البطاقات",
    "accountBNumber": ""
} */
    intilizeForm (){
      return this.fb.group({
        employeeId:[this.employeeBank.employeeId,Validators.required],
        bankAId : [this.employeeBank.bankAId,Validators.required],
        branchAId : [this.employeeBank.branchAId,Validators.required],
        accountANumber : [this.employeeBank.accountANumber,Validators.required],

        bankBId : [this.employeeBank.bankBId,Validators.required],
        branchBId : [this.employeeBank.branchBId,Validators.required],
        accountBNumber : [this.employeeBank.accountBNumber,Validators.required],
      })
    }
    addStartDate(ev){
      var date= moment(ev.value).format();

      this.form.patchValue({startFrom :date})
       console.log(date);
     }
  onNoClick(){
    this.dialogRef.close(false);
  }

  onBankChange(methodAorB:string, bankId:number){
    console.log(bankId);
    if(methodAorB=='A'){
      this.form.patchValue({bankAId :bankId})
      this.employeeBank.branchAId=null;

    }
    else if(methodAorB=='B'){
      this.form.patchValue({bankBId :bankId})
      this.employeeBank.branchBId=null;

    }
   //this.form.patchValue({bankAId:bankId});
   this.loadBankBranches( methodAorB, bankId);

   //this.employeeBank.bankAId=bankId;

  }
  onBankBranchChange(methodAorB:string, branchId){
    console.log(branchId);

    if(methodAorB=='A'){
      this.form.patchValue({branchAId :branchId})
      this.employeeBank.branchAId=branchId;
    }
    else if(methodAorB=='B'){
      this.form.patchValue({branchBId :branchId})
      this.employeeBank.branchBId=branchId;
    }

  }
  onSubmit(){
    this.employeeBankService.editEmployeeBankAccount(this.form.value).subscribe(x=>{

      this.dialogRef.close(true);
    })

//Object.assign(this.form.value,this.employeeBank);

console.log(this.form.value);

  }
}
