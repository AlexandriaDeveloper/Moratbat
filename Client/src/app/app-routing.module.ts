import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [

  { path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule)
},
  { path: 'employee',
   loadChildren: () => import('./employee/employee.module')
   .then(m => m.EmployeeModule)
   },
   { path: 'employee-bank',data:{animation : 'slideInAnimation'},
   loadChildren: () => import('./employee-bank/employee-bank.module')
   .then(m => m.EmployeeBankModule)
   },
  { path: 'employee-grade',data:{animation : 'slideInAnimation'}, loadChildren: () => import('./employee-grade/employee-grade.module').then(m => m.EmployeeGradeModule) },

  { path: 'bank',data:{animation : 'slideInAnimation'}, loadChildren: () => import('./bank/bank.module').then(m => m.BankModule) },

  { path: 'accounts-tree',data:{animation : 'slideInAnimation'}, loadChildren: () => import('./accounts-tree/accounts-tree.module').then(m => m.AccountsTreeModule) },

  { path: 'employee-basic-financial-data',data:{animation : 'slideInAnimation'}, loadChildren: () => import('./employee-basic-financial-data/employee-basic-financial-data.module').then(m => m.EmployeeBasicFinancialDataModule) },

  { path: 'employee-part-time',data:{animation : 'slideInAnimation'}, loadChildren: () => import('./employee-part-time/employee-part-time.module').then(m => m.EmployeePartTimeModule) },

  { path: 'collection',data:{animation : 'slideInAnimation'}, loadChildren: () => import('./collection/collection.module').then(m => m.CollectionModule) },
  {path:'not-found',component :NotFoundComponent},
   {path :'**', redirectTo: 'not-found'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
