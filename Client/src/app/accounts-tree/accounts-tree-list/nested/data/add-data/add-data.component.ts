import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddBankDialogComponent } from 'src/app/bank/bank/add-bank-dialog/add-bank-dialog.component';
import { IAccountTree } from 'src/app/shared/models/IAccountTree';
import { IAccountTreeDetails } from 'src/app/shared/models/IAccountTreeDetails';
import { AccountsTreeService } from 'src/app/shared/services/features/accounts-tree.service';

@Component({
  selector: 'app-add-data',
  templateUrl: './add-data.component.html',
  styleUrls: ['./add-data.component.scss']
})
export class AddDataComponent implements OnInit ,AfterViewInit {
  accountTreeDetails : IAccountTreeDetails;
  form : FormGroup;
  id:number=1;
  constructor(public dialogRef: MatDialogRef<AddBankDialogComponent>,

    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,private accountsTreeService: AccountsTreeService) {}

    ngOnInit(): void {

      this.accountsTreeService.getMaxId(this.data.accountParentId).subscribe((x:number)=>{
        this.id=x;
      })
      this.form=this.intilizeForm();
    }
    ngAfterViewInit(): void {

    }



      intilizeForm (){
        return this.fb.group({
          id:[this.id,Validators.required],
          name : ['',Validators.required],
          accountTreeId:[this.data.accountParentId,Validators.required],
        })
      }
    onNoClick(){
      this.dialogRef.close(false);
    }
    onSubmit(){
      this.form.patchValue({id:this.id});
      this.accountsTreeService.addAccountTreeDataElement(this.form.value).subscribe(x=>{
        this.dialogRef.close(true);
      })
    }
}
