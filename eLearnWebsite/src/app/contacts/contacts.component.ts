import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
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
    'email'
  ];

  teachersData: any;
  dataSource: MatTableDataSource<TeachersBySchool>;

  ngOnInit() {
    this.teachersService.getTeachersBySchool(9).subscribe(x => {
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
