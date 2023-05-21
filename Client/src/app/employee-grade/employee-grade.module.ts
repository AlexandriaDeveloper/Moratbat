import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeGradeRoutingModule } from './employee-grade-routing.module';
import { EmployeeGradeComponent } from './employee-grade.component';


@NgModule({
  declarations: [
    EmployeeGradeComponent
  ],
  imports: [
    CommonModule,
    EmployeeGradeRoutingModule
  ]
})
export class EmployeeGradeModule { }
