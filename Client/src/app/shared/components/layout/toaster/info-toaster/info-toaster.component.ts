import { Component, Inject, Input, inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA, MatSnackBarRef } from '@angular/material/snack-bar';

@Component({
  selector: 'app-info-toaster',
  templateUrl: './info-toaster.component.html',
  styleUrls: ['./info-toaster.component.scss']
})
export class InfoToasterComponent {
  snackBarRef = inject(MatSnackBarRef);
  @Input('header-msg') headerMsg=this.data.headerMsg;
  @Input('message') message=this.data.message;
  /**
   *
   */
  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: any) {
console.log(data);
  }


OnClose(){
    this.snackBarRef.dismiss();
}
}
