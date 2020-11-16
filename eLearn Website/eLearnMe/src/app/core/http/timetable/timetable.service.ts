import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GetTTByDisciple } from '../../../shared/models/getTTbyDisciple'

@Injectable({
  providedIn: 'root'
})
export class TimetableService {

  private apiUrl = "https://localhost:44331/api/";

  constructor(private http: HttpClient) { }

  public getTTbyDisciple (disciple_id: number, day: number ): Observable<GetTTByDisciple>{
    return this.http.get<GetTTByDisciple>(this.apiUrl + 'TimeTable?disciple_id=' + disciple_id + '&day=' + day);
  }
}
