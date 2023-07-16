import { Component, Inject, OnInit, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Collection } from 'src/app/shared/models/collection';
import { CollectionService } from 'src/app/shared/services/features/collection.service';

@Component({
  selector: 'app-add-edit-collection-dialog',
  templateUrl: './add-edit-collection-dialog.component.html',
  styleUrls: ['./add-edit-collection-dialog.component.scss']
})
export class AddEditCollectionDialogComponent implements OnInit,AfterViewInit {
  model : Collection=new Collection();
  form : FormGroup;
  state:string;
  title :string;
  constructor(public dialogRef: MatDialogRef<AddEditCollectionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,private collectionService: CollectionService) {}
  ngOnInit(): void {
console.log(this.data);

    this.state=this.data.title;
    this.title=  this.state ==='add'?'تكوين مجموعه جديدة':'تعديل مجموعه';
    if(this.state==='edit'){
      this.model= this.data.item;

    }
    else{
      this.model=new Collection();
    }


    this.form=this.intilizeForm();
  }
  ngAfterViewInit(): void {
//    throw new Error('Method not implemented.');

  }
    intilizeForm (){
      return this.fb.group({
        id:[this.model.id,Validators.required],
        name :[this.model.name,Validators.required],
      })
    }
  onNoClick(){
    this.dialogRef.close(false);
  }
  onSubmit(){
    if(this.state==='add'){
      this.collectionService.addCollection(this.form.value).subscribe(x =>
        this.dialogRef.close(true)
      )
    }

    else {
      this.collectionService.editCollection(this.form.value).subscribe(x =>
        this.dialogRef.close(true)
      )
    }

  }
}
