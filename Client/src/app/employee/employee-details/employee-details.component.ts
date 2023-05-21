import { Component, AfterViewInit, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeBasicInfo } from 'src/app/shared/models/Employee';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.scss']
})
export class EmployeeDetailsComponent implements OnInit {
  id:number;

constructor (private  router: ActivatedRoute)
{}
ngOnInit(): void {
  this.id=this.router.snapshot.params['id'];
  }

}
