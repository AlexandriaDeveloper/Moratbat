import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeBasicFinancialDataComponent } from './employee-basic-financial-data.component';
import { UploadComponent } from './upload/upload.component';

const routes: Routes = [
  { path: '', component: EmployeeBasicFinancialDataComponent,data:{animation : 'routeAnimations'}  },
  { path: 'upload', component: UploadComponent ,data:{animation : 'routeAnimations'} }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeBasicFinancialDataRoutingModule { }
