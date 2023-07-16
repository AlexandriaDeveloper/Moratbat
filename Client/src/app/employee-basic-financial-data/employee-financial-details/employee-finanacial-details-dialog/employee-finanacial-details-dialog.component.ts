import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-employee-finanacial-details-dialog',
  templateUrl: './employee-finanacial-details-dialog.component.html',
  styleUrls: ['./employee-finanacial-details-dialog.component.scss']
})
export class EmployeeFinanacialDetailsDialogComponent implements OnInit {
  constructor(public dialogRef: MatDialogRef<EmployeeFinanacialDetailsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {}
  ngOnInit(): void {
console.log(this.data.accountName);

  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
