import { Component, OnInit, ViewChild } from '@angular/core';
import { DiscipleToken } from 'src/models/DiscipleToken';
import { TimeTableService } from '../../../services/time-table.service'
import { AccountService } from '../../../services/account.service'

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
  user: DiscipleToken;
  classId: number;

  constructor(private ttService: TimeTableService, private accountService: AccountService) {
    this.user = JSON.parse(localStorage.getItem('user'));
  }

  ngOnInit() {
    console.log(this.user.id);
    this.currDate = new Date();
    var day = this.currDate.getDay();
    if (day === 0 || 6) {
      this.showWeekend = true;
    }
    else
    {
      this.ttService.getTTbyDisciple(this.user.classId, day).subscribe(x => {
        this.showTT = true;
        this.dataSource = x;
     });
    }
  }
}
