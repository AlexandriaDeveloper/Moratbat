import { Component, Input, inject, OnInit, AfterViewInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EmployeePartTimeService } from 'src/app/shared/services/features/employee-part-time.service';
import { EndEmployeePartTimeDialogComponent } from '../end-employee-part-time-dialog/end-employee-part-time-dialog.component';

@Component({
  selector: 'app-employee-part-time-info',
  templateUrl: './employee-part-time-info.component.html',
  styleUrls: ['./employee-part-time-info.component.scss']
})
export class EmployeePartTimeInfoComponent implements OnInit,AfterViewInit {
@Input('inPartTime') inPartTime:boolean;
@Input('employeeId') employeeId:number;
employeePartTimeList :any;
/**
 *
 */


constructor( private employeePartTimeService : EmployeePartTimeService,private dialog :MatDialog) {
}
  ngOnInit(): void {
    this.employeePartTimeService.getEmployeePartTimeHistoryByEmployeeId(this.employeeId).subscribe(
      (data:any) => this.employeePartTimeList = data.value
    );
  }
  ngAfterViewInit(): void {

  }
  endPartTimeDialog(row){console.log(row);
    let dialogRef = this.dialog.open(EndEmployeePartTimeDialogComponent, {
      width: '550px',
      disableClose: true,
      data:{id:row.id},

    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){



      }
    });
  }
}
