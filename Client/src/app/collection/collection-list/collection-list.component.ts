import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { MatTableConfigs } from 'src/app/shared/components/table/table-configs/mat-table-config';
import { SearchData, TableComponent, sortData } from 'src/app/shared/components/table/table.component';
import { CollectionParam } from 'src/app/shared/models/param';
import { CollectionService } from 'src/app/shared/services/features/collection.service';
import { AddEditCollectionDialogComponent } from './add-edit-collection-dialog/add-edit-collection-dialog.component';
import { Collection } from 'src/app/shared/models/collection';
import { DeleteDialogComponent } from 'src/app/shared/components/layout/delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-collection-list',
  templateUrl: './collection-list.component.html',
  styleUrls: ['./collection-list.component.scss']
})
export class CollectionListComponent implements OnInit ,AfterViewInit {
  displayedColumns: MatTableConfigs = {
    editable :  {
      edit:true,
      select : true,
      delete :true
    },
    columnHeader: [
    {
      value: 'name',
      text: 'اسم المجموعه ',
      search: true,
      sort:false
    },

    {
      value: 'count',
      text: 'عدد الموظفين المسجلين بالمجموعه',
      search: false,
      sort:false
    },

  ]
}
@ViewChild('myTable',{static:false}) table :TableComponent;
data;
  param : CollectionParam =new CollectionParam();

    constructor(private collectionService : CollectionService ,
      private dialog :MatDialog,
    private router: Router){}
  ngOnInit(): void {
    this.loadData();
}
  ngAfterViewInit(): void {
}
  loadData (){
    this.collectionService
    .getCollections(this.param)
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
  this.router.navigateByUrl('collection/collection-list/'+ev)
}
onEdit(ev){
  console.log(ev);
  this.openDialog ('edit', ev)

}
openDialog(title :string, item?: Collection){


let dialogRef = this.dialog.open(AddEditCollectionDialogComponent, {
  width: '450px',
  data:{item,title },
  disableClose: true,
  panelClass:['dialog']
});

dialogRef.afterClosed().subscribe(result => {
  this.loadData();
  //this.animal = result;
});
}
onDelete(ev){
 let dialogRef = this.dialog.open(DeleteDialogComponent, {
   width: '550px',
   disableClose: true,
   data:{title:'حذف مجموعه',message:`انت على وشك حذف ${ev.name} هل انت متأكد ؟؟!`},
 })

 dialogRef.afterClosed().subscribe(result => {
  if(result){

    this.collectionService.deleteCollection(ev.id).subscribe(x=>{
      this.loadData();
    })
  }

 // this.loadData();
  //this.animal = result;
});
}
}
