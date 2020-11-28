import { Component, Input, OnInit } from '@angular/core';
import { TimeTableService } from 'src/services/time-table.service';

@Component({
  selector: 'app-single-announce',
  templateUrl: './single-announce.component.html',
  styleUrls: ['./single-announce.component.sass']
})
export class SingleAnnounceComponent implements OnInit {

  @Input() announceId: number;
  
  announceRecord: any;

  constructor(private ttService: TimeTableService) {}

  ngOnInit(): void {
    this.ttService.getSingleAnnounce(this.announceId).subscribe(x => {
      this.announceRecord = x;
    })
  }

}
