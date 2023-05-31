import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddPromotionComponent } from '../../employee-grade/add-promotion/add-promotion.component';
import { EmployeeGradeService } from 'src/app/shared/services/features/employee-grade.service';
import { GradeService } from 'src/app/shared/services/features/grade.service';

@Component({
  selector: 'app-employee-promotions',
  templateUrl: './employee-promotions.component.html',
  styleUrls: ['./employee-promotions.component.scss']
})
export class EmployeePromotionsComponent {

  constructor(public dialog: MatDialog,
    private employeeGradeService : EmployeeGradeService,
    private grades :GradeService){}

  openDialog(): void {
    const dialogRef = this.dialog.open(AddPromotionComponent, {
      // data: {name: this.name, animal: this.animal},
      disableClose:true,
      panelClass:['dialog']
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      // this.animal = result;
    });
  }

  getCode(ev){
    console.log(ev);
    //this.employeeGradeService.getEmployeeGradeByEmployeeId(ev.employeeId).subscribe(x => console.log(x))



  }
}
