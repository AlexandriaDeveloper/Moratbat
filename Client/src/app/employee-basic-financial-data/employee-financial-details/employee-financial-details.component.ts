import { EmployeeBasicFinancialDataService } from 'src/app/shared/services/features/employee-basic-financial-data.service';
import { Component, Input, AfterViewInit, OnInit } from '@angular/core';
import * as moment from 'moment';
import { MatDialog } from '@angular/material/dialog';
import { EmployeeFinanacialDetailsDialogComponent } from './employee-finanacial-details-dialog/employee-finanacial-details-dialog.component';
import { AddEmployeeBasicFinancialDialogComponent } from '../add-employee-basic-financial-dialog/add-employee-basic-financial-dialog.component';

@Component({
  selector: 'app-employee-financial-details',
  templateUrl: './employee-financial-details.component.html',
  styleUrls: ['./employee-financial-details.component.scss']
})
export class EmployeeFinancialDetailsComponent implements OnInit, AfterViewInit {
  @Input('employee') employee : any;
  peekDate = moment(Date.now()).format();
  response ;

  /**
   *
   */
  constructor(private employeeBasicFinancialDataService: EmployeeBasicFinancialDataService, private dialog : MatDialog) {

  }
  ngOnInit(): void {
    console.log(this.employee);

  }
  ngAfterViewInit(): void {
    console.log(this.employee);

    this.loadData();
  }

  loadData(){



    this.employeeBasicFinancialDataService
    .getEmployeeBasicSallaryInfo(this.employee.id,this.peekDate)
    .subscribe(
      (x:any) =>
{

      this.response=x.value
}    )
  }
  changeDate(ev){

    this.peekDate= moment(ev.value).format();


    this.loadData();
  }

  getAccountDetailsData(accountName){

    if(accountName === 'الاجر الوظيفى')
    {
      this.employeeBasicFinancialDataService.getEmployeeDataByAccountTreeId(this.employee.id,'21110105',this.peekDate).subscribe(
        (x:any) =>{
          console.log(x.value);
          this.openAccountTreeDialog(x.value,accountName);
        }
      )
    }
    if(accountName === 'الاجر المكمل')
    {
      this.employeeBasicFinancialDataService.getEmployeeMokamelData(this.employee.id,this.peekDate).subscribe(
        (x:any) =>{
          console.log(x.value);

          this.openAccountTreeDialog(x.value,accountName);
        }
      )
    }
    if(accountName === 'الحافز التعويضى')
    {
      this.employeeBasicFinancialDataService.getEmployeeDataByAccountTreeId(this.employee.id,'21110326',this.peekDate).subscribe(
        (x:any) =>{
          this.openAccountTreeDialog(x.value,accountName);
        }
      )
    }

  }

  openAccountTreeDialog(data,accountName){
    console.log(data);

    let dialogRef = this.dialog.open(EmployeeFinanacialDetailsDialogComponent, {
      width: '650px',
      maxHeight: '650px',
      data: {
      accountName : accountName,
      data
      },
      disableClose: true,
      panelClass:['dialog']
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);

      //this.loadData();
      //this.animal = result;
    });

  }

  openAddAccountTreeDialog(){


    let dialogRef = this.dialog.open(AddEmployeeBasicFinancialDialogComponent, {
      width: '650px',
      maxHeight: '850px',
      data: {
        employeeId : this.employee.id
      },
      disableClose: true,
      panelClass:['dialog']
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);

      //this.loadData();
      //this.animal = result;
    });

  }

}
