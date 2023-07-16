import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountsTreeComponent } from './accounts-tree.component';
import { AccountsTreeListComponent } from './accounts-tree-list/accounts-tree-list.component';
import { NestedComponent } from './accounts-tree-list/nested/nested.component';
import { DataComponent } from './accounts-tree-list/nested/data/data.component';


const routes: Routes = [
  { path: '', component: AccountsTreeComponent,data:{animation : 'routeAnimations'}  },
  { path: 'list', component: AccountsTreeListComponent,data:{animation : 'routeAnimations'}  },
  { path: 'list/:id', component: NestedComponent,data:{animation : 'routeAnimations'}  },
  { path: 'data/:id', component: DataComponent,data:{animation : 'routeAnimations'}  }


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountsTreeRoutingModule { }
