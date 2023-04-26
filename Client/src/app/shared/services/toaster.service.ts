import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SuccessToasterComponent } from '../components/layout/toaster/success-toaster/success-toaster.component';
import { FailToasterComponent } from '../components/layout/toaster/fail-toaster/fail-toaster.component';
import { InfoToasterComponent } from '../components/layout/toaster/info-toaster/info-toaster.component';


@Injectable({
  providedIn: 'root'
})
export class ToasterService {
  private durationInSeconds = 5;
  constructor(private _snackBar: MatSnackBar) { }

  openSuccessToaster(message,headerMsg='تم التنفيذ') {
    this._snackBar.openFromComponent(SuccessToasterComponent, {
      duration: this.durationInSeconds * 1000,
      horizontalPosition:'right',
      verticalPosition:'top',
      panelClass:['success-toaster'],
      data:{message,headerMsg}
    });

  }
  openFailToaster(message,headerMsg ='خطأ') {
    this._snackBar.openFromComponent(FailToasterComponent, {
      duration: this.durationInSeconds * 1000,
      horizontalPosition:'right',
      verticalPosition:'top',
      panelClass:['fail-toaster'],
      data:{message,headerMsg}
    });
  }
  openInfoToaster(message,headerMsg='تنويه') {
    this._snackBar.openFromComponent(InfoToasterComponent, {
      duration: this.durationInSeconds * 1000,
      horizontalPosition:'right',
      verticalPosition:'top',
      panelClass:['info-toaster'],
      data:{message,headerMsg}
    });
  }
}
