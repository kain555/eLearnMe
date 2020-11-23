import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ContactsService } from './contacts.service';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Contacts } from './contacts.model';
import { DataSource } from '@angular/cdk/collections';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject, fromEvent, merge, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MatMenuTrigger } from '@angular/material/menu';
import { SelectionModel } from '@angular/cdk/collections';
import { FormComponent } from './form/form.component';
import { DeleteComponent } from './delete/delete.component';
import { TimeTableService } from 'src/services/time-table.service';
import { MatTableDataSource } from '@angular/material/table';
import { TeachersBySchool } from '../../models/ITeachersBySchool'

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.sass']
})
export class ContactsComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private teachersService: TimeTableService) {
  }

  displayedColumns: string[] = [
    'teacherName',
    'teacherSurname',
    'className',
    'subjectName',
    'email',
    'director'
  ];

  teachersData: any;
  dataSource: MatTableDataSource<TeachersBySchool>;

  ngOnInit() {
    this.teachersService.getTeachersBySchool(1).subscribe(x => {
      this.teachersData = x;
      this.dataSource = new MatTableDataSource(this.teachersData);
      console.log(this.dataSource);
  });
  
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
