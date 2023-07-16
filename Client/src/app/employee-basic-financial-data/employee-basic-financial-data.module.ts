import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeBasicFinancialDataRoutingModule } from './employee-basic-financial-data-routing.module';
import { EmployeeBasicFinancialDataComponent } from './employee-basic-financial-data.component';
import { SharedModule } from '../shared/shared.module';
import { UploadComponent } from './upload/upload.component';
import { EmployeeFinancialDetailsComponent } from './employee-financial-details/employee-financial-details.component';
import { EmployeeFinanacialDetailsDialogComponent } from './employee-financial-details/employee-finanacial-details-dialog/employee-finanacial-details-dialog.component';
import { AddEmployeeBasicFinancialDialogComponent } from './add-employee-basic-financial-dialog/add-employee-basic-financial-dialog.component';


@NgModule({
  declarations: [
    EmployeeBasicFinancialDataComponent,
    UploadComponent,
    EmployeeFinancialDetailsComponent,
    EmployeeFinanacialDetailsDialogComponent,
    AddEmployeeBasicFinancialDialogComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    EmployeeBasicFinancialDataRoutingModule,

  ],exports:[EmployeeFinancialDetailsComponent]
})
export class EmployeeBasicFinancialDataModule { }
