import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './employee.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeFileUploadComponent } from './employee-file-upload/employee-file-upload.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { EmployeePromotionsComponent } from './employee-promotions/employee-promotions.component';

const routes: Routes = [
  { path: '', component: EmployeeComponent,data:{animation : 'slideInAnimation'}   },
  { path: 'list', component: EmployeeListComponent,data:{animation : 'slideInAnimation'}  },
  { path: 'details/:id', component: EmployeeDetailsComponent,data:{animation : 'slideInAnimation'} },
  { path: 'file-upload', component: EmployeeFileUploadComponent,data:{animation : 'slideInAnimation'} },
  { path: 'employee-prmotion', component: EmployeePromotionsComponent,data:{animation : 'slideInAnimation'} },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
