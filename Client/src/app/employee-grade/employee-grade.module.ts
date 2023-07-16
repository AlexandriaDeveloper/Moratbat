import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeGradeRoutingModule } from './employee-grade-routing.module';
import { EmployeeGradeComponent } from './employee-grade.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    EmployeeGradeComponent,

  ],
  imports: [
    CommonModule,
    SharedModule,
    EmployeeGradeRoutingModule
  ]
})
export class EmployeeGradeModule { }
