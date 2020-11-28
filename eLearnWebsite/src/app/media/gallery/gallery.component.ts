
import { Component } from '@angular/core';
import { Announce } from 'src/models/IAnnounce';
import { TimeTableService } from 'src/services/time-table.service';
@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.scss'],
})
export class GalleryComponent {

  announceObj: any;
  arrayOfId: Array<number>;
  
  constructor(private ttService: TimeTableService) {
    this.ttService.getAnnounces(1).subscribe(x => {
      this.announceObj = x;
      this.arrayOfId = this.announceObj.map(x => x.announceId);
    })
  }

  listOfAnnounce: any;

  ngOnInit(): void {
     
  }

}
