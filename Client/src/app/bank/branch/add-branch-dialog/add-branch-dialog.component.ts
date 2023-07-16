import { Component, AfterViewInit, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BankBranchesService } from 'src/app/shared/services/features/bank-branches.service';

@Component({
  selector: 'app-add-branch-dialog',
  templateUrl: './add-branch-dialog.component.html',
  styleUrls: ['./add-branch-dialog.component.scss']
})
export class AddBranchDialogComponent implements OnInit, AfterViewInit  {
  form : FormGroup;
  constructor(public dialogRef: MatDialogRef<AddBranchDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,private bankService: BankBranchesService) {}
  ngOnInit(): void {
    this.form=this.intilizeForm();
  }
  ngAfterViewInit(): void {
//    throw new Error('Method not implemented.');

  }



    intilizeForm (){
      return this.fb.group({
        name : ['',Validators.required],
        bankId:[this.data.bank.id,Validators.required]
      })
    }
  onNoClick(){
    this.dialogRef.close();
  }
  onSubmit(){
    this.bankService.addBankBranch(this.form.value).subscribe(x=>{
      console.log(x);
      this.onNoClick();
    })
  }
}
