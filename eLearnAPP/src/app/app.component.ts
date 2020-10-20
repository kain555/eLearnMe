import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'protractor';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  oceny: any;
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getOceny();
  }
  getOceny() {
    this.http.get('https://localhost:44331/api/oceny').subscribe(response => {
      response = this.oceny;
      console.log(this.oceny);
    }, error => {
      console.log(error);
    })
  }
}

