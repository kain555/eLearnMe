import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetTTByDisciple } from '../models/IGetTTByDisciple'
import { School } from '../models/ISchool'

@Injectable({
  providedIn: 'root'
})
export class TimeTableService {

  private apiUrl = "https://localhost:44331/api/";

  constructor(private http: HttpClient) { }

  public getTTbyDisciple (classId: number, day: number, schoolId: number): Observable<GetTTByDisciple>{
    return this.http.get<GetTTByDisciple>(this.apiUrl + 'TimeTable/GetTimeTableDataDay?classId=' + classId + '&day=' + day + '&schoolId=' + schoolId);
  }

  public getSchool (id: number): Observable<School> {
    return this.http.get<School>(this.apiUrl + 'School?id=' + id);
  }

  public getTTWeek (classId: number, day: number, schoolId: number): Observable<GetTTByDisciple>{
    return this.http.get<GetTTByDisciple>(this.apiUrl + 'TimeTable/GetTimeTableDataWeek?classId=' + classId + '&day=' + day + '&schoolId=' + schoolId);
  }

  public getGradesByDisciple (id: number, subject: string): Observable<any>{
    return this.http.get<any>(this.apiUrl + 'grades/GradesByDS?id=' + id + '&subject=' + subject);
  }
}
