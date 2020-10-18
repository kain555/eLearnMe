import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AnyARecord } from 'dns';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  users: any;
  constructor(private http: HttpClient) {}

  ngOnInit() {

  }
}
