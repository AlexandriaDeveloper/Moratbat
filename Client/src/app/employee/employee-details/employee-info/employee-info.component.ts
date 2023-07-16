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

@Input('employee') employee:EmployeeBasicInfo;
constructor( ){}
  ngOnInit(): void {

  }

}
