import { AfterViewInit, Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CopyCollection } from 'src/app/shared/models/collection';
import { CollectionService } from 'src/app/shared/services/features/collection.service';

@Component({
  selector: 'app-copy-collection-dialog',
  templateUrl: './copy-collection-dialog.component.html',
  styleUrls: ['./copy-collection-dialog.component.scss']
})
export class CopyCollectionDialogComponent implements OnInit,AfterViewInit {
  model : CopyCollection=new CopyCollection();
  form : FormGroup;
  state:string;
  title :string;
  constructor(public dialogRef: MatDialogRef<CopyCollectionDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,private fb :FormBuilder,private collectionService: CollectionService,
   ) {}
  ngOnInit(): void {
console.log(this.data);

    this.state=this.data.title;
    this.title= 'نسخ مجموعه ';
    if(this.state==='edit'){
      this.model= this.data.item;

    }
    else{
      this.model=new CopyCollection();
    }


    this.form=this.intilizeForm();
  }
  ngAfterViewInit(): void {
//    throw new Error('Method not implemented.');

  }
    intilizeForm (){
      return this.fb.group({
        collectionId:[this.data.collectionId,Validators.required],
        name :[this.model.name,Validators.required],
      })
    }
  onNoClick(){
    this.dialogRef.close(false);
  }
  onSubmit(){

      this.collectionService.copyCollection(this.form.value).subscribe(x =>
        this.dialogRef.close(true)

      )


  }
}
