import { Component, Inject, OnInit, AfterViewInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeeCollectionService } from 'src/app/shared/services/features/employee-collection.service';

@Component({
  selector: 'app-add-employee-to-collection-dialog',
  templateUrl: './add-employee-to-collection-dialog.component.html',
  styleUrls: ['./add-employee-to-collection-dialog.component.scss']
})
export class AddEmployeeToCollectionDialogComponent implements OnInit ,AfterViewInit {
form : FormGroup;
title;
employee;
  constructor(public dialogRef: MatDialogRef<AddEmployeeToCollectionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,private collectionService: EmployeeCollectionService){}
  ngOnInit(): void {
    console.log(this.data);

  }

  ngAfterViewInit(): void {

  }
  intilizeForm (){
    return this.fb.group({
      collectionId : [ this.data.id,Validators.required],
      employeeId :[this.employee.id,Validators.required],
      isActive :[true,Validators.required],
    })
  }
  getEmployeeByCodeEventHandler(ev){
    console.log(ev);
    this.employee=ev;
    this.form=this.intilizeForm();
  }
  onNoClick(){
    this.dialogRef.close(false);
  }
  onSubmit(){console.log(this.form.value);
    this.collectionService.addEmployeeToCollection(this.form.value).subscribe(x =>
      this.dialogRef.close(true)
    )
  }
}
