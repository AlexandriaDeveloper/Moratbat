import { Component, Inject, ViewEncapsulation } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { DeleteDialogModel } from 'src/app/shared/models/delete-dialog.model';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.scss']
})
export class DeleteDialogComponent {
  isDeleted = true;
constructor(public dialogRef: MatDialogRef<DeleteDialogComponent>,
  @Inject(MAT_DIALOG_DATA) public data: DeleteDialogModel) {}


  onNoClick(): void {
    this.dialogRef.close(!this.isDeleted);
  }
  delete(){
    this.dialogRef.close(this.isDeleted);
  }
}
