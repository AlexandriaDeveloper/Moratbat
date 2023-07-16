import { Component, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as moment from 'moment';
import { EmployeeBankService } from 'src/app/shared/services/features/employee-bank.service';

@Component({
  selector: 'app-close-employee-account',
  templateUrl: './close-employee-account-dialog.component.html',
  styleUrls: ['./close-employee-account-dialog.component.scss']
})
export class CloseEmployeeAccountDialogComponent {
  form : FormGroup;

  constructor(public dialogRef: MatDialogRef<CloseEmployeeAccountDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,
    private employeeBankService : EmployeeBankService) {}
    ngOnInit(): void {
      this.form=this.intilizeForm();
    }
    intilizeForm (){
      return this.fb.group({
        bankId : [this.data.bankId,Validators.required],
        employeeId:[this.data.employeeId,Validators.required],
        endAt:['',Validators.required]


      })
    }
    addEndDate(ev){
      var date= moment(ev.value).format();

      this.form.patchValue({endAt :date})
       console.log(date);
     }
    onNoClick(){
      this.dialogRef.close(false);
    }
    onSubmit(){
        this.dialogRef.close(this.form.value);
    }
}
