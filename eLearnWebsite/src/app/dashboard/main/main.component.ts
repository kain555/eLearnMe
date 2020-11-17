import { Component, OnInit, ViewChild } from '@angular/core';
import { TimeTableService } from '../../../services/time-table.service'

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
})
export class MainComponent implements OnInit {

  displayedColumns: string[] = ['subject', 'lessonHour', 'teacherName', 'teacherSurname', 'className', 'join']
  dataSource: any;

  constructor(private ttService: TimeTableService) {
  }

  ngOnInit() {
    var now = new Date();
    var day = now.getDay();
   this.ttService.getTTbyDisciple(5, day).subscribe(x => {
     this.dataSource = x;
    console.log(this.dataSource);
   });
  }
}
