import { Component, AfterViewInit, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { AccountsTreeService } from 'src/app/shared/services/features/accounts-tree.service';
import { AddAccountTreeComponent } from './add-account-tree/add-account-tree.component';


@Component({
  selector: 'app-accounts-tree-list.',
  templateUrl: './accounts-tree-list.component.html',
  styleUrls: ['./accounts-tree-list.component.scss']
})
export class AccountsTreeListComponent implements OnInit ,AfterViewInit{

 selectedQanon;
 parentBudgetItems:any;
 copiedCode:string;
 data ;
 selectedAccountTreeId:number;
constructor(private accountsTreeService : AccountsTreeService,public dialog: MatDialog) {

}
  ngOnInit(): void {
   // throw new Error('Method not implemented.');
   this.getParentAccountsTree();
  }
  ngAfterViewInit(): void {
   // throw new Error('Method not implemented.');
  }
  getParentAccountsTree(){

    this.data=null;
    this.parentBudgetItems=null;
    this.accountsTreeService.getParentsBudgetItems().subscribe(x => this.parentBudgetItems=x);

  }
  getAccountTreeItems(ev){
    this.selectedAccountTreeId=ev;
    this.data=null;
    this.accountsTreeService.getChildrenBudgetItems(ev).subscribe(x =>
      this.data=x
      );
  }
  copy(val){
    const selBox = document.createElement('textarea');
    selBox.style.position = 'fixed';
    selBox.style.left = '50%';
    selBox.style.top = '300px';

    selBox.style.backgroundColor='#1b5e20';
    selBox.style.textAlign='center';
    selBox.style.verticalAlign='middle';
    selBox.style.fontSize='15px'
    selBox.style.opacity = '0';
    selBox.value = val;
    this.copiedCode =val;
    document.body.appendChild(selBox);
    selBox.focus();
    selBox.select();
    document.execCommand('copy');
    setTimeout(() => {
      this.copiedCode=null;
    },2000)

  }
  addAccountTree(){
    let dialogRef = this.dialog.open(AddAccountTreeComponent, {
      width: '450px',
      data: {
        accountParentId:this.selectedAccountTreeId
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
