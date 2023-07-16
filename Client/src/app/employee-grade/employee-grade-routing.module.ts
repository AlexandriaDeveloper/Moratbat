import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeGradeComponent } from './employee-grade.component';

const routes: Routes = [{ path: '', component: EmployeeGradeComponent ,data:{animation : 'routeAnimations'} }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeGradeRoutingModule { }
