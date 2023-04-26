import { Component, Inject, Input, inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA, MatSnackBarRef } from '@angular/material/snack-bar';

@Component({
  selector: 'app-fail-toaster',
  templateUrl: './fail-toaster.component.html',
  styleUrls: ['./fail-toaster.component.scss']
})
export class FailToasterComponent {
  snackBarRef = inject(MatSnackBarRef);
  @Input('header-msg') headerMsg=this.data.headerMsg;
  @Input('message') message=this.data.message;
  /**
   *
   */
  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: any) {


  }


OnClose(){
    this.snackBarRef.dismiss();
}
}
