import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeeComponent } from './employee.component';
import { SharedModule } from '../shared/shared.module';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeFileUploadComponent } from './employee-file-upload/employee-file-upload.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { EmployeeInfoComponent } from './employee-details/employee-info/employee-info.component';
import { EmployeePromotionsComponent } from './employee-promotions/employee-promotions.component';
import { AddPromotionComponent } from './employee-promotions/add-promotion/add-promotion.component';
import { EmployeeDetailsDialogComponent } from './employee-details-dialog/employee-details-dialog.component';


@NgModule({
  declarations: [
    EmployeeComponent,
    EmployeeListComponent,
    EmployeeFileUploadComponent,
    EmployeeDetailsComponent,
    EmployeeInfoComponent,
    EmployeePromotionsComponent,
    AddPromotionComponent,
    EmployeeDetailsDialogComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    EmployeeRoutingModule
  ]
})
export class EmployeeModule { }
