import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeePartTimeRoutingModule } from './employee-part-time-routing.module';
import { EmployeePartTimeComponent } from './employee-part-time.component';
import { EmployeePartTimeInfoComponent } from './employee-part-time-info/employee-part-time-info.component';
import { SharedModule } from '../shared/shared.module';
import { AddEmployeePartTimeDialogComponent } from './add-employee-part-time-dialog/add-employee-part-time-dialog.component';
import { EndEmployeePartTimeDialogComponent } from './end-employee-part-time-dialog/end-employee-part-time-dialog.component';



@NgModule({
  declarations: [
    EmployeePartTimeComponent,
    EmployeePartTimeInfoComponent,
    AddEmployeePartTimeDialogComponent,
    EndEmployeePartTimeDialogComponent
  ],
  imports: [
    CommonModule,
    EmployeePartTimeRoutingModule,SharedModule
  ],
  exports:[
    EmployeePartTimeInfoComponent
  ]
})
export class EmployeePartTimeModule { }
