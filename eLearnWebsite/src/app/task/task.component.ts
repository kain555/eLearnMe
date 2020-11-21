import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.sass'],
})
export class TaskComponent implements OnInit {

  subjects: string[] = ["Język Polski", "Matematyka", "W-F", "Język Angielski", "Biologia", "Chemia", "Fizyka", "Muzyka", "Plastyka"];

  constructor()
  {}
  
  ngOnInit(): void {
  }
}
