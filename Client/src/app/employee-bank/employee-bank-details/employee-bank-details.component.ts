import { AfterViewInit, Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeBankService } from 'src/app/shared/services/features/employee-bank.service';
import { AddEmployeeBankAccountDialogComponent } from '../add-employee-bank-account-dialog/add-employee-bank-account-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { DeleteDialogComponent } from 'src/app/shared/components/layout/delete-dialog/delete-dialog.component';
import { CloseEmployeeAccountDialogComponent } from '../close-employee-account-dialog/close-employee-account-dialog.component';

@Component({
  selector: 'app-employee-bank-details',
  templateUrl: './employee-bank-details.component.html',
  styleUrls: ['./employee-bank-details.component.scss']
})
export class EmployeeBankDetailsComponent implements OnInit,AfterViewInit {

  employeeId :number;
  employeeBank :any
  constructor(private employeeBankService : EmployeeBankService,private router : ActivatedRoute, private dialog : MatDialog){}
  ngAfterViewInit(): void {
   // throw new Error('Method not implemented.');
  }
  ngOnInit(): void {
    this.employeeId = this.router.snapshot.params['id'];
    this.loadData();
  }

  loadData(){
    this.employeeBankService.getEmployeeBankAccountByEmployeeId(this.employeeId).subscribe(data=>{
      if(data.value){
        console.log(data.value);
      }
      this.employeeBank = data.value;
    });
  }
  deleteEmployeeBankDialog(){
    let dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '550px',
      disableClose: true,
      data:{title:'حذف بنك',message:`انت على وشك حذف الحساب البنكى هل انت متأكد ؟!`},

    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){

        this.employeeBankService.deleteEmployeeBankAccount(this.employeeId,this.employeeBank.bankId).subscribe(x=>{
          this.employeeBank = null;
        })

      }
    });
  }
  closeEmployeeBankDialog(){
    let dialogRef = this.dialog.open(CloseEmployeeAccountDialogComponent, {
      width: '550px',
      disableClose: true,
      data:{employeeId: this.employeeId,bankId:this.employeeBank.bankId},

    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){

        this.employeeBankService.closeEmployeeBankAccount(result).subscribe(x=>{
          this.employeeBank = null;
        })

      }
    });
  }
  openAddEmployeeBankAccountDialog(){
    let dialogRef = this.dialog.open(AddEmployeeBankAccountDialogComponent, {
      width: '550px',
      disableClose: true,
     data:{ employeeId:this.employeeId, employeeBank:this.employeeBank},

    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.loadData();

      }
    });
  }

}
