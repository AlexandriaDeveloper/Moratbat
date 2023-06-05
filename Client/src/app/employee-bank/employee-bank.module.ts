import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeBankRoutingModule } from './employee-bank-routing.module';
import { EmployeeBankComponent } from './employee-bank.component';
import { EmployeeBankDetailsComponent } from './employee-bank-details/employee-bank-details.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    EmployeeBankComponent,
    EmployeeBankDetailsComponent
  ],
  imports: [
    CommonModule,
    EmployeeBankRoutingModule,
    SharedModule
  ],
  exports:[
    EmployeeBankDetailsComponent
  ]
})
export class EmployeeBankModule { }
