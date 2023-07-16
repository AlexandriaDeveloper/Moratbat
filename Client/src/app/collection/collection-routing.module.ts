import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollectionComponent } from './collection.component';
import { CollectionListComponent } from './collection-list/collection-list.component';
import { EmployeesCollectionComponent } from './employees-collection/employees-collection.component';

const routes: Routes = [
  { path: '', component: CollectionComponent ,data:{animation : 'slideInAnimation'} },

  { path: 'collection-list', component: CollectionListComponent ,data:{animation : 'slideInAnimation'} },
  { path: 'collection-list/:id', component: EmployeesCollectionComponent ,data:{animation : 'slideInAnimation'} },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CollectionRoutingModule { }
