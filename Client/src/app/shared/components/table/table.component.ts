import {
  AfterViewInit,
  Component,
  Input,
  ViewChild,
  OnInit,
  Output,
  EventEmitter,
  ChangeDetectorRef,
  ElementRef,
  ViewChildren,
  QueryList,
} from '@angular/core';
import {
  MatPaginator,
  MatPaginatorModule,
  PageEvent,
} from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTable, MatTableModule } from '@angular/material/table';
import {
  MatTableConfigs,
  columnHeader,
} from './table-configs/mat-table-config';
import {
  Observable,
  Subscription,
  debounceTime,
  distinctUntilChanged,
  fromEvent,
  map,
} from 'rxjs';
import { TableDataSource } from './table-datasource';
import {
  animate,
  keyframes,
  state,
  style,
  transition,
  trigger,
} from '@angular/animations';
import SortBtnComponent from './sort-btn/sort-btn.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { SearchTextComponent } from './search-text/search-text.component';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],

  animations: [
    trigger('rowUpdate', [
      transition(
        'void => *',
        animate(
          '500ms',
          keyframes([
            style({ opacity: 0.3, transform: 'translateX(' + 0 + 'px)' }),
            style({ opacity: 0.5, transform: 'translateX(-' + 100 + 'px)' }),
            style({ opacity: 1, transform: 'translateX(' + 0 + 'px)' }),
          ])
        )
      ),
      transition(
        '* => void',
        animate(
          '500ms',
          keyframes([
            style({ opacity: 1, transform: 'translateX(' + 0 + 'px)' }),
            style({ opacity: 0.5, transform: 'translateX(-' + 100 + 'px)' }),
            style({ opacity: 0.3, transform: 'translateX(' + 0 + 'px)' }),
          ])
        )
      ),
    ]),
  ],
})
export class TableComponent implements OnInit, AfterViewInit {
  matDataSource;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) matTable!: MatTable<any>;
  @ViewChildren('searchInput') searchInputElement: QueryList<ElementRef>;
  @ViewChild('searchInput2') searchInputElement2: ElementRef;
  @ViewChildren('sortChildren') sortChildren: QueryList<SortBtnComponent>;

  @Input('displayedColumns') displayedColumns: MatTableConfigs;
  @Input('searchColumns') searchColumns: string[];
  @Output('pageChangeEvent') pageChangeEvent: EventEmitter<PageEvent> =
    new EventEmitter();
  @Output('searchEvent') searchChangeEvent: EventEmitter<any> =
    new EventEmitter();
  @Output('sortEvent') sortChangeEvent: EventEmitter<sortData> =
    new EventEmitter();
  @Output('onSelect') onSelectEvent: EventEmitter<number> = new EventEmitter();
  @Output('onDelete') onDeleteEvent: EventEmitter<number> = new EventEmitter();
  @Output('onEdit') onEditEvent: EventEmitter<number> = new EventEmitter();
  headerCols: string[];
  @Input('data') data;
  dataSource: TableDataSource = new TableDataSource([]);
  sevice: Observable<any>;
  searchSubscription;
  searchInput = new SearchData();
  iconName = 'sort_by_alpha';

  constructor(private cd: ChangeDetectorRef) {}
  ngOnInit(): void {
    if (this.displayedColumns.editable !== null) {
      if (
        this.displayedColumns.editable?.delete === true ||
        this.displayedColumns.editable?.edit === true ||
        this.displayedColumns.editable?.select === true
      ) {
        let headerColums: columnHeader[] = [
          { value: 'action', text: '', search: false },
        ];
        this.displayedColumns.columnHeader = [
          ...headerColums,
          ...this.displayedColumns.columnHeader,
        ];
      }
    }

    this.headerCols = this.displayedColumns.columnHeader.map((x) => x.value);
  }

  public loadData(data?) {
    this.dataSource = new TableDataSource(this?.data?.records, this.paginator);
    this.matTable.dataSource = this.dataSource;
  }

  ngAfterViewInit(): void {}

  search(element) {
    this.searchChangeEvent.emit(element);
  }
  changePage(ev: PageEvent) {
    this.pageChangeEvent.emit(ev);
  }
  sortData(ev) {
    console.log(this.sortChildren);
    this.sortChildren.forEach((x) => {
      if (x.elementName !== ev.active) {
        x.reset();
      }
    });

    this.sortChangeEvent.emit(ev);
  }
  btnClick(btnName, row) {
    if (btnName === 'select') {
      this.onSelectEvent.emit(row.id);
    }
    if (btnName === 'edit') {
      this.onEditEvent.emit(row);
    }
    if (btnName === 'delete') {
      this.onDeleteEvent.emit(row);
    }
  }
}
export class SearchData {
  elementName: string;
  value: string;
}
export class sortData {
  active: string;
  direction: string;
}
