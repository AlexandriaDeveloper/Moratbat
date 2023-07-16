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
import { AddPromotionComponent } from '../employee-grade/add-promotion/add-promotion.component';

import { EmployeeBankModule } from '../employee-bank/employee-bank.module';
import { EmployeeBasicFinancialDataModule } from '../employee-basic-financial-data/employee-basic-financial-data.module';
import { EmployeePartTimeModule } from '../employee-part-time/employee-part-time.module';
import { EmployeeDetailsDialogComponent } from "../shared/components/employee-details-dialog/employee-details-dialog.component";


@NgModule({
    declarations: [
        EmployeeComponent,
        EmployeeListComponent,
        EmployeeFileUploadComponent,
        EmployeeDetailsComponent,
        EmployeeInfoComponent,
        EmployeePromotionsComponent,
        AddPromotionComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        EmployeeRoutingModule,
        EmployeeBankModule,
        EmployeeBasicFinancialDataModule,
        EmployeePartTimeModule,
        EmployeeDetailsDialogComponent
    ]
})
export class EmployeeModule { }
