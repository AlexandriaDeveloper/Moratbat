import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../shared/services/features/employee.service';
import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { EmployeeBasicInfo } from 'src/app/shared/models/Employee';
import { ResponseObject } from 'src/app/shared/models/ResponseObject';
const DATA  =[
  {
    name : 'كود تجارة',
    value : 'tegaraCode'
  },
  {
     name : 'كود طب',
    value : 'tabCode'
  }
 ]
@Component({
  selector: 'app-employee-details-dialog',
  templateUrl: './employee-details-dialog.component.html',
  styleUrls: ['./employee-details-dialog.component.scss']
})

export class EmployeeDetailsDialogComponent implements OnInit,AfterViewInit {
@Output('employeeEvent')  employeeEvent = new EventEmitter<EmployeeBasicInfo>();
@Input('employeeCode') employeeCode

employeeCodeForm :FormGroup;
searchBy = DATA;

employee :EmployeeBasicInfo;
/**
 *
 */
constructor(
  private fb : FormBuilder,
  private employeeService : EmployeeService ) {
}
  ngAfterViewInit(): void {
    //throw new Error('Method not implemented.');
  }
  ngOnInit(): void {
    //throw new Error('Method not implemented.');
    this.employeeCodeForm=this.initilizeForm();
  }
  initilizeForm(){
return this.fb.group({
  searchBy :[ '',Validators.required],
  code:['',Validators.required]
})
  }

  onSubmit(){
    let param = this.employeeCodeForm.value
    this.employeeService.getEmployeeBasicInfoByCode(param).subscribe((x:ResponseObject<EmployeeBasicInfo>) =>{
      console.log(x);
      this.employee= x.value;
      this.employeeEvent.emit(x.value)
    })
}
}
