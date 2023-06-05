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
   { path: 'employee-bank',
   loadChildren: () => import('./employee-bank/employee-bank.module')
   .then(m => m.EmployeeBankModule)
   },
  { path: 'employee-grade', loadChildren: () => import('./employee-grade/employee-grade.module').then(m => m.EmployeeGradeModule) },

  { path: 'bank', loadChildren: () => import('./bank/bank.module').then(m => m.BankModule) }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
