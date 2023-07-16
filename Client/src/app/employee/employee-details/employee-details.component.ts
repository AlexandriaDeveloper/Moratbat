import { Component, AfterViewInit, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { combineLatest, concatMap, forkJoin, map, of } from 'rxjs';
import { AddEmployeePartTimeDialogComponent } from 'src/app/employee-part-time/add-employee-part-time-dialog/add-employee-part-time-dialog.component';
import { slideInAnimation } from 'src/app/shared/animations/sliedInAnimation';
import { EmployeeBasicInfo } from 'src/app/shared/models/Employee';
import { EmployeeService } from 'src/app/shared/services/features/employee.service';
import { GradeService } from 'src/app/shared/services/features/grade.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.scss'],
  animations:[  slideInAnimation]
})
export class EmployeeDetailsComponent implements OnInit {
  id:number;
  employee:EmployeeBasicInfo;

constructor (private  router: ActivatedRoute,private employeeService : EmployeeService ,private gradeService : GradeService,private matDialog :MatDialog)
{}
ngOnInit(): void {
  this.id=this.router.snapshot.params['id'];

    let emp=  this.employeeService.getEmployeeBasicInfo(this.id);

    emp
    .pipe(map((p:any) => this.employee=p.value),concatMap((t:any) =>
      {

        if(t?.gradeId!==null)
         return  this.gradeService.getGradeById(t.gradeId)
         .pipe(map((x2:any)=> {
          this.employee.employeeGrade= x2.value.name
        return this.employee
        }));
        else{
          this.employee.employeeGrade='غير محدد'
          return of(this.employee);
        }
      }
      ) )
    .subscribe((x:any) =>console.log(x)


     );
  }
  openPartTimeDialog(){

    let dialogRef = this.matDialog.open( AddEmployeePartTimeDialogComponent , {
      width: '550px',
      disableClose: true,
      data:{employee:this.employee},

    });

    dialogRef.afterClosed().subscribe(result => {
      if(result){
          if(result){
            this.employee.inPartTime=true;
            this.employee.hasPartTimeHistory=true;
          }

      }
    });

  }


}
