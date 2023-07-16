
import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddBankDialogComponent } from 'src/app/bank/bank/add-bank-dialog/add-bank-dialog.component';
import { IAccountTree } from 'src/app/shared/models/IAccountTree';

import { AccountsTreeService } from 'src/app/shared/services/features/accounts-tree.service';


@Component({
  selector: 'app-add',
  templateUrl: './add-account-tree.component.html',
  styleUrls: ['./add-account-tree.component.scss']
})
export class AddAccountTreeComponent implements OnInit ,AfterViewInit {
  accountTreeObj : IAccountTree;

  form : FormGroup;
  constructor(public dialogRef: MatDialogRef<AddBankDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,private accountsTreeService: AccountsTreeService) {}
    ngOnInit(): void {

      this.form=this.intilizeForm();
    }
    ngAfterViewInit(): void {
  //    throw new Error ('Method not implemented.');
      //this.accountTreeObj.AccountParentId=this.data.accountParentId;
    }



      intilizeForm (){
        return this.fb.group({
          id:['',Validators.required],
          name : ['',Validators.required],
          accountParentId:[this.data.accountParentId,Validators.required],
        })
      }
    onNoClick(){
      this.dialogRef.close(false);
    }
    onSubmit(){

      this.accountsTreeService.addAccountTree(this.form.value).subscribe(x=>{
        console.log(x);
        this.dialogRef.close(true);
      })
    }
}
