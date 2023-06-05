import { EmployeeBasicInfo } from './../../../shared/models/Employee';
import { Component, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../../../shared/services/features/employee.service';
import { GradeService } from 'src/app/shared/services/features/grade.service';
import { concat, concatMap, map } from 'rxjs';

@Component({
  selector: 'app-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.scss']
})
export class EmployeeInfoComponent implements OnInit {
@Input('id') id :number
employee:EmployeeBasicInfo;
constructor( private employeeService : EmployeeService ,private gradeService : GradeService){}
  ngOnInit(): void {
    // this.employeeService.getEmployeeBasicInfo(this.id).subscribe((x:ResponseObject< EmployeeBasicInfo>) => {
    //   this.employee=x.value;
    // });
  let emp=  this.employeeService.getEmployeeBasicInfo(this.id);

emp
.pipe(map((p:any) => this.employee=p.value),concatMap((t:any) =>
  {
    if(t.gradeId)
     return  this.gradeService.getGradeById(t.gradeId)
    else{
      return null;
    }
  }
  ) )
.subscribe((x:any) => this.employee.gradeId=x.value.name);
  }

}
