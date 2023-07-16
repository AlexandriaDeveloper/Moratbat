import { EmployeesInCollectionParam } from './../../shared/models/param';
import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableConfigs } from 'src/app/shared/components/table/table-configs/mat-table-config';
import { TableComponent, SearchData, sortData } from 'src/app/shared/components/table/table.component';
import { CollectionService } from 'src/app/shared/services/features/collection.service';
import { AddEditCollectionDialogComponent } from '../collection-list/add-edit-collection-dialog/add-edit-collection-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { AddEmployeeToCollectionDialogComponent } from './add-employee-to-collection-dialog/add-employee-to-collection-dialog.component';
import { EmployeeCollectionService } from 'src/app/shared/services/features/employee-collection.service';
import { DeleteDialogComponent } from 'src/app/shared/components/layout/delete-dialog/delete-dialog.component';
import { UploadEmployeesToCollectionComponent } from './upload-employees-to-collection/upload-employees-to-collection.component';
import { CopyCollectionDialogComponent } from './copy-collection-dialog/copy-collection-dialog.component';

@Component({
  selector: 'app-employees-collection',
  templateUrl: './employees-collection.component.html',
  styleUrls: ['./employees-collection.component.scss']
})
export class EmployeesCollectionComponent implements OnInit,AfterViewInit {

  displayedColumns: MatTableConfigs = {
    editable :  {
      edit:false,
      select : true,
      delete :true
    },
    columnHeader: [
    {
      value: 'name',
      text: 'اسم لموظف ',
      search: true,
      sort:false
    },

    {
      value: 'tabCode',
      text: 'كود طب',
      search: true,
      sort:false
    }
    ,

    {
      value: 'tegaraCode',
      text: 'كود تجارة',
      search: true,
      sort:false
    }
    ,

    {
      value: 'nationalId',
      text: 'الرقم القومى',
      search: true,
      sort:false
    }
    ,

    {
      value: 'isActive',
      text: 'الحالة',
      search: false,
      sort:false
    }

  ]
}
@ViewChild('myTable',{static:false}) table :TableComponent;
data;

  param = new EmployeesInCollectionParam();
  id;

  constructor (
    private router : ActivatedRoute,
    private route : Router,
    private dialog :MatDialog,
    private collectionService : EmployeeCollectionService) {}
  ngOnInit(): void {
    this.id=this.router.snapshot.params['id'];
    this.loadData();

  }
  ngAfterViewInit(): void {
    //throw new Error('Method not implemented.');
  }
  loadData (){
    this.collectionService
    .getEmployeeInCollection(this.id,this.param)
    .subscribe((x:any) => {
      this.data=x
      this.table.data=x.value
      this.table.loadData(x.value)
      });
};

  pageChange(ev){
    this.param.pageIndex=++ev.pageIndex;
    this.param.pageSize=ev.pageSize;
    this.loadData();
  }
  onSearch(event :SearchData ){
    // console.log(event);
     this.param[event.elementName]=event.value;
     this.loadData();
}
onSortChange(ev:sortData){
this.param.active =ev.active;
this.param.direction=ev.direction;
this.loadData();
}
onSelect(ev){
  //this.router.navigateByUrl('collection/collection-list/'+ev)
}
openAddEmployeeToCollectionDialog(){
  let dialogRef = this.dialog.open(AddEmployeeToCollectionDialogComponent, {
    width: '650px',
    data:{id : this.id },
    disableClose: true,
    panelClass:['dialog']
  });

  dialogRef.afterClosed().subscribe(result => {
    this.loadData();
    //this.animal = result;
  });
  }

  copyCollectionDialog(){
    let dialogRef = this.dialog.open(CopyCollectionDialogComponent, {
      width: '650px',
      data:{collectionId : this.id },
      disableClose: true,
      panelClass:['dialog']
    });

    dialogRef.afterClosed().subscribe(result => {
      //this.loadData();
      //this.animal = result;
      if(result){
        this.route.navigate(['collection','collection-list'])

      }

    });
    }
  onDelete(ev){console.log(ev);
    let dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '550px',
      disableClose: true,
      data:{title:'حذف مجموعه',message:`انت على وشك حذف ${ev.name} هل انت متأكد ؟؟!`},
    })
    dialogRef.afterClosed().subscribe(result => {
    if(result){
      this.collectionService.deleteEmployeeFromCollection(ev.id).subscribe(x=>{
        this.loadData();
      })
    }
    });
  }
  downloadFile(){
    return this.collectionService.downloadPhoneExcelFile().subscribe();
  }
  uploadFile(){
    let dialogRef = this.dialog.open(UploadEmployeesToCollectionComponent, {
      width: '550px',
      disableClose: true,
      data:{collectionId:this.id},
    })
    dialogRef.afterClosed().subscribe(result => {
    if(result){
      this.loadData();
    }
    });
  }

}
