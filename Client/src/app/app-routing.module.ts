import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [

  { path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule)
},
  { path: 'employee',
   loadChildren: () => import('./employee/employee.module')
   .then(m => m.EmployeeModule)
   },

  { path: 'app', loadChildren: () => import('./employee-grade/employee-grade.module').then(m => m.EmployeeGradeModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
