import { BankService } from './../../../shared/services/features/bank.service';
import { Component, Inject, OnInit, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-bank-dialog',
  templateUrl: './add-bank-dialog.component.html',
  styleUrls: ['./add-bank-dialog.component.scss']
})
export class AddBankDialogComponent implements OnInit,AfterViewInit{
  form : FormGroup;
  constructor(public dialogRef: MatDialogRef<AddBankDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,private bankService: BankService) {}
  ngOnInit(): void {
    this.form=this.intilizeForm();
  }
  ngAfterViewInit(): void {
//    throw new Error('Method not implemented.');

  }



    intilizeForm (){
      return this.fb.group({
        name : ['',Validators.required],
      })
    }
  onNoClick(){
    this.dialogRef.close();
  }
  onSubmit(){
    this.bankService.addBank(this.form.value).subscribe(x=>{
      console.log(x);
      this.onNoClick();
    })
  }
}
