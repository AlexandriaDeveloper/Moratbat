import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddBankDialogComponent } from 'src/app/bank/bank/add-bank-dialog/add-bank-dialog.component';
import { BankService } from 'src/app/shared/services/features/bank.service';
import { EmployeeCollectionService } from 'src/app/shared/services/features/employee-collection.service';

@Component({
  selector: 'app-upload-employees-to-collection',
  templateUrl: './upload-employees-to-collection.component.html',
  styleUrls: ['./upload-employees-to-collection.component.scss']
})
export class UploadEmployeesToCollectionComponent implements OnInit ,AfterViewInit {
  form : FormGroup;
  constructor(public dialogRef: MatDialogRef<AddBankDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,private employeeCollectionService: EmployeeCollectionService) {}
  ngOnInit(): void {
    this.form=this.intilizeForm();
  }
  ngAfterViewInit(): void {
//    throw new Error('Method not implemented.');

  }



    intilizeForm (){
      return this.fb.group({
        collectionId:[ this.data.collectionId,Validators.required],
        file : ['',Validators.required],
      })
    }
  onNoClick(){
    this.dialogRef.close(false);
  }
  onChange(event) {

    this.form.patchValue({file : event.target.files[0]})
}
  onSubmit(){
    console.log(this.form.value);

    this.employeeCollectionService.uploadEmployeeExcelFile(this.form.value).subscribe(x=>{
      this.dialogRef.close(true)

    })
  }
}
