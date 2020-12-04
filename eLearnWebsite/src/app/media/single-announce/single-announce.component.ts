import { Component, Input, OnInit } from '@angular/core';
import { TimeTableService } from 'src/services/time-table.service';

@Component({
  selector: 'app-single-announce',
  templateUrl: './single-announce.component.html',
  styleUrls: ['./single-announce.component.sass']
})
export class SingleAnnounceComponent implements OnInit {

  @Input() addDate: Date;
  @Input() announceContent: string;
  @Input() piority: string;
  @Input() kindOf: string;
  @Input() announcingBy: string;

  constructor(private ttService: TimeTableService) {}

  ngOnInit(): void {
  }

}
