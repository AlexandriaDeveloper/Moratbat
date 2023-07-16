import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountsTreeRoutingModule } from './accounts-tree-routing.module';
import { AccountsTreeComponent } from './accounts-tree.component';
import { SharedModule } from '../shared/shared.module';
import { AccountsTreeListComponent } from './accounts-tree-list/accounts-tree-list.component';
import { FormsModule } from '@angular/forms';
import { NestedComponent } from './accounts-tree-list/nested/nested.component';
import { DataComponent } from './accounts-tree-list/nested/data/data.component';
import { AddAccountTreeComponent } from './accounts-tree-list/add-account-tree/add-account-tree.component';
import { AddDataComponent } from './accounts-tree-list/nested/data/add-data/add-data.component';


@NgModule({
  declarations: [
    AccountsTreeComponent,
    AccountsTreeListComponent,
    NestedComponent,
    DataComponent,
    AddAccountTreeComponent,
    AddDataComponent
  ],
  imports: [
    CommonModule,
    AccountsTreeRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class AccountsTreeModule { }
