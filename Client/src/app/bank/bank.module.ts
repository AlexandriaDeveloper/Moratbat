import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BankRoutingModule } from './bank-routing.module';
import { BankComponent } from './bank.component';
import { SharedModule } from '../shared/shared.module';
import { BankListComponent } from './bank/bank-list/bank-list.component';
import { BranchListComponent } from './branch/branch-list/branch-list.component';
import { AddBankDialogComponent } from './bank/add-bank-dialog/add-bank-dialog.component';


@NgModule({
  declarations: [
    BankComponent,
    BankListComponent,
    BranchListComponent,
    AddBankDialogComponent
  ],
  imports: [
    CommonModule,
    BankRoutingModule,
    SharedModule
  ]
})
export class BankModule { }
