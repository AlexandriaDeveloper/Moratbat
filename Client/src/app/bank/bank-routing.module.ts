import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BankComponent } from './bank.component';
import { BankListComponent } from './bank/bank-list/bank-list.component';
import { BranchListComponent } from './branch/branch-list/branch-list.component';

const routes: Routes = [
  { path: '', component: BankComponent ,data:{animation : 'routeAnimations'} },
{ path: 'bank-list', component: BankListComponent ,data:{animation : 'routeAnimations'} },
{ path: 'bank-list/:id', component: BranchListComponent,data:{animation : 'routeAnimations'}  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BankRoutingModule { }
