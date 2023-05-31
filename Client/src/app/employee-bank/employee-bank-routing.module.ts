import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeBankComponent } from './employee-bank.component';

const routes: Routes = [
  {path:"",component:EmployeeBankComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeBankRoutingModule { }
