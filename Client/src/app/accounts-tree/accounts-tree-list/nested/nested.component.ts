import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AccountsTreeService } from 'src/app/shared/services/features/accounts-tree.service';
import { AddAccountTreeComponent } from '../add-account-tree/add-account-tree.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-nested',
  templateUrl: './nested.component.html',
  styleUrls: ['./nested.component.scss']
})
export class NestedComponent implements OnInit {
  parentId
  data ;
constructor(private accountsTreeService: AccountsTreeService,private router :ActivatedRoute,public dialog: MatDialog) {}
  ngOnInit(): void {
    this.parentId = this.router.snapshot.params['id'];
    this.loadData();
  }
  loadData(){
    this.accountsTreeService.getChildrenBudgetItems(this.parentId).subscribe((x:any) => this.data = x);
  }
  addAccountTree(){
    let dialogRef = this.dialog.open(AddAccountTreeComponent, {
      width: '450px',
      data: {
        accountParentId:this.parentId
      },
      disableClose: true,
      panelClass:['dialog']
    });

    dialogRef.afterClosed().subscribe(result => {

      this.loadData();
      //this.animal = result;
    });
  }
}
