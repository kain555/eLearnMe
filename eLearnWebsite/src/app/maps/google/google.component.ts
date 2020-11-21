import { Component, Input } from '@angular/core';
import { TimeTableService } from 'src/services/time-table.service';

@Component({
  selector: 'app-google',
  templateUrl: './google.component.html',
  styleUrls: ['./google.component.scss']
})
export class GoogleComponent {
  @Input() subjectName: string;
  discipleId = 3;
  gradesDiscipleObject: Array<any>;
  gradesArray: any;
  avg: number;
  sum = 0;
  constructor(private ttService: TimeTableService) { 
  }

  ngOnInit(): void {
    this.ttService.getGradesByDisciple(this.discipleId, this.subjectName).subscribe(x => {
      this.gradesDiscipleObject = x;
      let result = this.gradesDiscipleObject.map(a => a.gValue);
      if (result.length === 0){
        this.gradesArray = ["Brak ocen z tego przedmiotu"];
        this.avg = 0;
      }
      else if (result.length > 0){
        for( var i = 0; i < result.length; i++ ){
          this.sum += parseInt( result[i], 10 );
        }
      this.avg = this.sum/result.length;
      this.gradesArray = result;
      }
      
    })
  }

}