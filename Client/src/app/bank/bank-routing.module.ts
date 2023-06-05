import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BankComponent } from './bank.component';
import { BankListComponent } from './bank/bank-list/bank-list.component';
import { BranchListComponent } from './branch/branch-list/branch-list.component';

const routes: Routes = [
  { path: '', component: BankComponent },
{ path: 'bank-list', component: BankListComponent },
{ path: 'bank-list/:id', component: BranchListComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BankRoutingModule { }
