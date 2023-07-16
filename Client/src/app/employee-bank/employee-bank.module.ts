import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeBankRoutingModule } from './employee-bank-routing.module';
import { EmployeeBankComponent } from './employee-bank.component';
import { EmployeeBankDetailsComponent } from './employee-bank-details/employee-bank-details.component';
import { SharedModule } from '../shared/shared.module';
import { AddEmployeeBankAccountDialogComponent } from './add-employee-bank-account-dialog/add-employee-bank-account-dialog.component';
import { CloseEmployeeAccountDialogComponent } from './close-employee-account-dialog/close-employee-account-dialog.component';



@NgModule({
  declarations: [
    EmployeeBankComponent,
    EmployeeBankDetailsComponent,
    AddEmployeeBankAccountDialogComponent,
    CloseEmployeeAccountDialogComponent
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
