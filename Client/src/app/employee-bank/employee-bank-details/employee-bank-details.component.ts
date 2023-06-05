import { AfterViewInit, Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmployeeBankService } from 'src/app/shared/services/features/employee-bank.service';

@Component({
  selector: 'app-employee-bank-details',
  templateUrl: './employee-bank-details.component.html',
  styleUrls: ['./employee-bank-details.component.scss']
})
export class EmployeeBankDetailsComponent implements OnInit,AfterViewInit {

  employeeId :number;
  employeeBank :any
  constructor(private employeeBankService : EmployeeBankService,private router : ActivatedRoute){}
  ngAfterViewInit(): void {
   // throw new Error('Method not implemented.');
  }
  ngOnInit(): void {
    this.employeeId = this.router.snapshot.params['id'];
    this.employeeBankService.getEmployeeBankAccountByEmployeeId(this.employeeId).subscribe(data=>{
      if(data.value){
        console.log(data.value);
      }
      this.employeeBank = data.value;
    });
  }

}
