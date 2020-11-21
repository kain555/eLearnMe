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
    if (day === 6 || 0) {
      this.showWeekend = true;
    }
    else
    {
      this.ttService.getTTbyDisciple(1, day, 1).subscribe(x => {
        this.showTT = true;
        this.dataSource = x;
     });
    }
  }
}
