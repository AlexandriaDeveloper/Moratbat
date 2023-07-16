import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import * as moment from 'moment';
import { EmployeePartTimeService } from 'src/app/shared/services/features/employee-part-time.service';

@Component({
  selector: 'app-end-employee-part-time-dialog',
  templateUrl: './end-employee-part-time-dialog.component.html',
  styleUrls: ['./end-employee-part-time-dialog.component.scss']
})
export class EndEmployeePartTimeDialogComponent implements OnInit , AfterViewInit {
  form : FormGroup;
id;


  constructor(public dialogRef: MatDialogRef<EndEmployeePartTimeDialogComponent>,
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

        id:[this.data.id,Validators.required],
        endDate:['',Validators.required]


      })
    }
    addEndDate(ev){
      var date= moment(ev.value).format();
      this.form.patchValue({endDate :date})
     }
  onNoClick(){
    this.dialogRef.close(false);
  }



  onSubmit(){
    console.log(this.form.value);

    this.employeePartTimeService.endPartTimeToEmployee(this.form.value).subscribe(x=>{

      this.dialogRef.close(true);
    })


  }
}
