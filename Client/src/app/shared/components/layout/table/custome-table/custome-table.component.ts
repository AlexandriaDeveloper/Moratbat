import { Component, AfterViewInit, ViewChild, Input, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-custome-table',
  templateUrl: './custome-table.component.html',
  styleUrls: ['./custome-table.component.scss']
})
export class CustomeTableComponent implements OnInit, AfterViewInit {

  @Input('displayColumns') displayedColumns :string[] ;
  @Input('data') data :any[] =[] ;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  dataSource ;

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource(this.data);
  }

  ngAfterViewInit(): void {


    this.dataSource.paginator = this.paginator;
  }


}


