import { EmployeePartTimeService } from 'src/app/shared/services/features/employee-part-time.service';
import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as moment from 'moment';
import { AddBankDialogComponent } from 'src/app/bank/bank/add-bank-dialog/add-bank-dialog.component';
import { Bank, BankBranch } from 'src/app/shared/models/bank';
import { BankBranchesService } from 'src/app/shared/services/features/bank-branches.service';
import { BankService } from 'src/app/shared/services/features/bank.service';
import { EmployeeBankService } from 'src/app/shared/services/features/employee-bank.service';

@Component({
  selector: 'app-add-employee-part-time-dialog',
  templateUrl: './add-employee-part-time-dialog.component.html',
  styleUrls: ['./add-employee-part-time-dialog.component.scss']
})
export class AddEmployeePartTimeDialogComponent implements OnInit,AfterViewInit {
  form : FormGroup;



  constructor(public dialogRef: MatDialogRef<AddEmployeePartTimeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,
    private employeePartTimeService:EmployeePartTimeService
   ) {}
  ngOnInit(): void {
    this.form=this.intilizeForm();
  }
  ngAfterViewInit(): void {

  }




    intilizeForm (){
      return this.fb.group({

        employeeId:[this.data.employee.id,Validators.required],
        details : ['',Validators.required],
        startDate:['',Validators.required]


      })
    }
    addStartDate(ev){
      var date= moment(ev.value).format();
      this.form.patchValue({startDate :date})
     }
  onNoClick(){
    this.dialogRef.close(false);
  }



  onSubmit(){
    console.log(this.form.value);

    this.employeePartTimeService.addPartTimeToEmployee(this.form.value).subscribe(x=>{

      this.dialogRef.close(true);
    })


  }
}
