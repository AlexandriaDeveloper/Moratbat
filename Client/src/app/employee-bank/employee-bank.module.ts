import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeBankRoutingModule } from './employee-bank-routing.module';
import { EmployeeBankComponent } from './employee-bank.component';



@NgModule({
  declarations: [
    EmployeeBankComponent
  ],
  imports: [
    CommonModule,
    EmployeeBankRoutingModule
  ],
  exports:[
    EmployeeBankComponent
  ]
})
export class EmployeeBankModule { }
 