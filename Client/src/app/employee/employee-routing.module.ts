import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { EmployeeFileUploadComponent } from './employee-file-upload/employee-file-upload.component';

const routes: Routes = [
  { path: '', component: EmployeeComponent },
  { path: 'details', component: EmployeeDetailsComponent },
  { path: 'file-upload', component: EmployeeFileUploadComponent },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
