import { QANON } from 'src/app/shared/models/constants';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmployeeBasicInfo } from 'src/app/shared/models/Employee';
import { EmployeeGradeService } from 'src/app/shared/services/features/employee-grade.service';
import { EMPTY } from 'rxjs';
import { GradeService } from 'src/app/shared/services/features/grade.service';
import * as moment from 'moment';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-promotion',
  templateUrl: './add-promotion.component.html',
  styleUrls: ['./add-promotion.component.scss']
})
export class AddPromotionComponent implements OnInit {
  form : FormGroup;
  employee : EmployeeBasicInfo;
  mainPosition;
  id=1;
  grades:any;
  selectedGradeId ;
constructor(public dialogRef: MatDialogRef<AddPromotionComponent>,
  @Inject(MAT_DIALOG_DATA) public data: any,
  private employeeGradeService : EmployeeGradeService,
  private gradeService : GradeService,
private  fb : FormBuilder
  ){}
  ngOnInit(): void {
    //throw new Error('Method not implemented.');
    this.form=this.initalizeForm()
  }

  initalizeForm (){
    return this.fb.group({
      employeeId :[this.employee?.id,Validators.required],
      gradeId:[this.selectedGradeId,Validators.required],
      startFrom :['',Validators.required],
      endAt:[null]
    });
  }
  onNoClick(){
    this.dialogRef.close();
  }
  getEmployeeByCodeEventHandler(ev){
    this.employee=ev;
    this.form.patchValue({employeeId :ev.id})
    this.employeeGradeService.getEmployeeGradeByEmployeeId(ev.id).subscribe(x => this.selectedGradeId=x);
    this.loadGrades(this.id);
  }
  addStartDate(ev){
   var date= moment(ev.value).format('DD-MM-YYYY');

   this.form.patchValue({startFrom :date})
    console.log(date);
  }
  addEndDate(ev){
    var date= moment(ev.value).format('DD-MM-YYYY');
    this.form.patchValue({endAt :date})
    console.log(date);
  }
  getQanonText(){

    let  Grade;
    if(this.employee.qanon==='Qanon81')
    {
      Grade= 'موظف'
    }
    if(this.employee.qanon==='Qanon49')
    {
      Grade= 'هيئه تدريس'
    }

    return Grade;
  }

  gradeChanege(ev){
    console.log(ev.value)
    this.form.patchValue({gradeId :ev.value})
  }
  loadGrades(id){
  this.gradeService.getGradesByParentId(id).subscribe((x:any) => this.grades=x.value);
  }
  onSubmit(){
    console.log(this.form.value);
  }
}
