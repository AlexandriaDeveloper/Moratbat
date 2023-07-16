import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AngularMaterialModule } from './angular-material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TopNavBarComponent } from './components/layout/top-nav-bar/top-nav-bar.component';
import { RouterModule } from '@angular/router';
import { CardIconsComponent } from './components/layout/card-icons/card-icons.component';
import { CustomeTableComponent } from './components/layout/table/custome-table/custome-table.component';
import { SuccessToasterComponent } from './components/layout/toaster/success-toaster/success-toaster.component';
import { FailToasterComponent } from './components/layout/toaster/fail-toaster/fail-toaster.component';
import { InfoToasterComponent } from './components/layout/toaster/info-toaster/info-toaster.component';
import { TableComponent } from './components/table/table.component';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { TestTableComponent } from './components/test-table/test-table.component';
import { SearchTextComponent } from './components/table/search-text/search-text.component';
import SortBtnComponent from './components/table/sort-btn/sort-btn.component';
import { DeleteDialogComponent } from './components/layout/delete-dialog/delete-dialog.component';





@NgModule({
  declarations: [
    TopNavBarComponent,
    CardIconsComponent,
    CustomeTableComponent,
    SuccessToasterComponent,
    FailToasterComponent,
    InfoToasterComponent,
    TableComponent,
    TestTableComponent,
    SearchTextComponent,
    SortBtnComponent,
    DeleteDialogComponent

  ],
  imports: [
    CommonModule,

    AngularMaterialModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule
  ],
  providers:[

  ],
  exports:[
    AngularMaterialModule,
    ReactiveFormsModule,
    HttpClientModule,
    TopNavBarComponent,
    CardIconsComponent,
    CustomeTableComponent,
    TableComponent,

  ],

})
export class SharedModule { }

