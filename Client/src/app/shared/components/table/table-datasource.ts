import { DataSource } from '@angular/cdk/collections';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { map } from 'rxjs/operators';
import { Observable, of as observableOf, merge, of } from 'rxjs';

// TODO: Replace this with your own data model type

export class TableDataSource extends DataSource<any> {

  paginator: MatPaginator | undefined;
  sort: MatSort | undefined;
  data:[];

  constructor(data:[], paginatorSource? :MatPaginator ) {
    super();
    if(paginatorSource!=null){
      this.paginator= paginatorSource;
    }
    this.data=data;

  }

  /**
   * Connect this data source to the table. The table will only update when
   * the returned stream emits new items.
   * @returns A stream of the items to be rendered.
   */
  connect(): Observable<any[]> {
  //    this.paginator.length= this.data.length;
    return of( this.data);

  }

  /**
   *  Called when the table is being destroyed. Use this function, to clean up
   * any open connections or free any held resources that were set up during connect.
   */
  disconnect(): void {}



}

