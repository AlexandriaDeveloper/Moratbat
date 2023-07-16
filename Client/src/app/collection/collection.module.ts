import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CollectionRoutingModule } from './collection-routing.module';
import { CollectionComponent } from './collection.component';
import { SharedModule } from '../shared/shared.module';
import { CollectionListComponent } from './collection-list/collection-list.component';
import { EmployeesCollectionComponent } from './employees-collection/employees-collection.component';
import { AddEditCollectionDialogComponent } from './collection-list/add-edit-collection-dialog/add-edit-collection-dialog.component';
import { AddEmployeeToCollectionDialogComponent } from './employees-collection/add-employee-to-collection-dialog/add-employee-to-collection-dialog.component';
import { EmployeeDetailsDialogComponent } from "../shared/components/employee-details-dialog/employee-details-dialog.component";
import { UploadEmployeesToCollectionComponent } from './employees-collection/upload-employees-to-collection/upload-employees-to-collection.component';
import { CopyCollectionDialogComponent } from './employees-collection/copy-collection-dialog/copy-collection-dialog.component';


@NgModule({
    declarations: [
        CollectionComponent,
        CollectionListComponent,
        EmployeesCollectionComponent,
        AddEditCollectionDialogComponent,
        AddEmployeeToCollectionDialogComponent,
        UploadEmployeesToCollectionComponent,
        CopyCollectionDialogComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        CollectionRoutingModule,
        EmployeeDetailsDialogComponent
    ]
})
export class CollectionModule { }
