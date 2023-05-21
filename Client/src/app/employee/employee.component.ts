import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../shared/services/features/employee.service';
import { ToasterService } from '../shared/services/toaster.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {
data:string[];
  constructor(private employeeService : EmployeeService,private toasterService : ToasterService){}
  ngOnInit(): void {
this.loadEmployees();
  }
  loadEmployees(){
  //  this.employeeService.getEmployees().subscribe( (x:string[]) => this.data =x);
  }
  openSuccessSnack(){

    //this.toasterService.openSuccessToaster();
    this.toasterService.openSuccessToaster('يوجد خطأ ');
  }
  openFailSnack(){
    //this.toasterService.openSuccessToaster();
    this.toasterService.openFailToaster('يوجد خطأ ');
  }
  openInfoSnack(){
    //this.toasterService.openSuccessToaster();
    this.toasterService.openInfoToaster('يوجد خطأ ','اهلا بكم');
  }
}
