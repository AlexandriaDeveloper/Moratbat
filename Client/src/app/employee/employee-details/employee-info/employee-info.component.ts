import { EmployeeBasicInfo } from './../../../shared/models/Employee';
import { Component, Input, AfterViewInit, OnInit } from '@angular/core';
import { EmployeeService } from '../../../shared/services/features/employee.service';
import { ResponseObject } from 'src/app/shared/models/ResponseObject';

@Component({
  selector: 'app-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.scss']
})
export class EmployeeInfoComponent implements OnInit {
@Input('id') id :number
employee:EmployeeBasicInfo;
constructor( private employeeService : EmployeeService){}
  ngOnInit(): void {
    this.employeeService.getEmployeeBasicInfo(this.id).subscribe((x:ResponseObject< EmployeeBasicInfo>) => {
      this.employee=x.value;

    });
  }

}
