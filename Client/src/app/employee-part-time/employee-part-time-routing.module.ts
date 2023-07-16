import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeePartTimeComponent } from './employee-part-time.component';

const routes: Routes = [{ path: '', component: EmployeePartTimeComponent ,data:{animation : 'routeAnimations'} }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeePartTimeRoutingModule { }
