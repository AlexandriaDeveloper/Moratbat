import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { AccountsTreeService } from 'src/app/shared/services/features/accounts-tree.service';
import { AddDataComponent } from './add-data/add-data.component';

@Component({
  selector: 'app-data',
  templateUrl: './data.component.html',
  styleUrls: ['./data.component.scss']
})
export class DataComponent implements OnInit {

data;
copiedCode;
selectedAccountTreeId;
    constructor( private accountsTreeService: AccountsTreeService,private router :ActivatedRoute,public dialog: MatDialog) {

    }
  ngOnInit(): void {
   this.selectedAccountTreeId = this.router.snapshot.params['id'];
   this.loadData();
  }

  loadData(){
    this.accountsTreeService.getChildrensAccountsTreeData(this.selectedAccountTreeId).subscribe((x:any) => {this.data = x;console.log(x);
    });
  }
  addNewBudgetItem(){

    let dialogRef = this.dialog.open(AddDataComponent, {
      width: '450px',
      data: {
        accountParentId:this.selectedAccountTreeId
      },
      disableClose: true,
      panelClass:['dialog']
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);

      this.loadData();
      //this.animal = result;
    });
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
}
