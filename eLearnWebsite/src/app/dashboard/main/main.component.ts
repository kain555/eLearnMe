import { Component, OnInit, ViewChild } from '@angular/core';
import { TimeTableService } from '../../../services/time-table.service'

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss'],
})
export class MainComponent implements OnInit {

  displayedColumns: string[] = ['subject', 'lessonHour', 'teacherName', 'roomName', 'join']
  dataSource: any;
  currDate: Date;
  showTT = false;
  showWeekend = false;

  constructor(private ttService: TimeTableService) {
  }

  ngOnInit() {
    this.currDate = new Date();
    var day = this.currDate.getDay();
    this.ttService.getTTbyDisciple(1, day, 1).subscribe(x => {
    if(day === 5 || 6){
      this.showWeekend = true;
      this.showTT = false;
    }
    else
    this.showTT = true;
    this.dataSource = x;
   });
  }
}
