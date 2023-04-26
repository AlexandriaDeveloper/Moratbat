import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';
import { SharedModule } from '../shared/shared.module';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { EmployeeFileUploadComponent } from './employee-file-upload/employee-file-upload.component';


@NgModule({
  declarations: [
    EmployeeComponent,
    EmployeeDetailsComponent,
    EmployeeFileUploadComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    EmployeeRoutingModule
  ]
})
export class EmployeeModule { }
