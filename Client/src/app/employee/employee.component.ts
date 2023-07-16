import { Component, OnInit } from '@angular/core';
import { ToasterService } from '../shared/services/toaster.service';
import { slideInAnimation } from '../shared/animations/sliedInAnimation';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
  animations:[  slideInAnimation]
})
export class EmployeeComponent implements OnInit {
data:string[];
  constructor(private toasterService : ToasterService){}
  ngOnInit(): void {
  }

}
