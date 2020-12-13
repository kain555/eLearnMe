import { Component, ViewChild, OnInit, TemplateRef } from '@angular/core';
import { FullCalendarComponent } from '@fullcalendar/angular';
import { EventInput, parseBusinessHours } from '@fullcalendar/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import timeGridPlugin from '@fullcalendar/timegrid';
import interactionPlugin from '@fullcalendar/interaction';
import listPlugin from '@fullcalendar/list';
import { MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Calendar } from './calendar.model';
import { MatRadioChange } from '@angular/material/radio';
import { FormDialogComponent } from './dialogs/form-dialog/form-dialog.component';
import { CalendarService } from './calendar.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TimeTableService } from 'src/services/time-table.service';
import { CalendarData } from '../../../src/models/CalendarData';

export class cData {
  id: number;
  title: string;
  start: Date;
  end: Date;
  className: string;
  groupId: string;
  details: string;
}

const d = new Date();
const month = d.getMonth();
const year = d.getFullYear();

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {
  @ViewChild('calendar', { static: false })
  calendar: Calendar | null;
  public addCusForm: FormGroup;
  dialogTitle: string;
  filterOptions = "Wszystkie";
  calendarData: any;
  businessHours: true;
  allCalendarRecords: any;
  allWeek: any;

  public filters = [
    { name: 'all', value: 'Wszystkie', checked: 'true' },
    { name: 'work', value: 'Matematyka', checked: 'false' },
    { name: 'personal', value: 'Język Polski', checked: 'false' },
    { name: 'important', value: 'Biologia', checked: 'false' },
    { name: 'travel', value: 'Plastyka', checked: 'false' },
    { name: 'friends', value: 'Fizyka', checked: 'false' }
  ];

  calendarVisible = true;
  calendarPlugins = [dayGridPlugin, timeGridPlugin, interactionPlugin, listPlugin];
  calendarWeekends = false;
  @ViewChild('callAPIDialog', { static: false }) callAPIDialog: TemplateRef<any>;
  calendarEvents: any;
  allCalendarData: Array<cData>;
  tempEvents: EventInput[];
  todaysEvents: EventInput[];

  constructor(
    private ttService: TimeTableService,
    private fb: FormBuilder,
    private dialog: MatDialog,
    public calendarService: CalendarService,
    private snackBar: MatSnackBar) {
    this.dialogTitle = 'Add New Event';
    this.calendar = new Calendar({});
    this.addCusForm = this.createContactForm(this.calendar);
  }

  recordsCalendar: cData[] = new Array();
    public ngOnInit(): void {
    this.getAllCalendarWeek();
    //this.calendarEvents = this.events();
    this.tempEvents = this.calendarEvents;
  }

  getAllCalendarWeek() {
    this.allCalendarRecords = this.ttService.getCalendarData(1).subscribe(x => {
      this.allWeek = x;

      for (let i = 0; i < this.allWeek.length; i++) {
        let days = [7,14,21,28];
        days.forEach(day => {
        this.recordsCalendar.push({
        id: this.allWeek[i].subjectName,
        title: this.allWeek[i].subjectName,
        start: new Date(year, month, this.allWeek[i].dayOfWeekId + day, this.allWeek[i].lessonHourS, this.allWeek[i].lessonMinuteS),
        end: new Date(year, month, this.allWeek[i].dayOfWeekId + day, this.allWeek[i].lessonHourE, this.allWeek[i].lessonMinuteE),
        className: "fc-event-warning",
        groupId: "travel",
        details: "Nauczyciel prowadzący lekcje: " + this.allWeek[i].name + " " + this.allWeek[i].surname,
        });
      });
      }
      console.log(this.recordsCalendar);
      this.calendarEvents = this.recordsCalendar;
    });
  }

  changeCategory(e: MatRadioChange) {
    this.filterOptions = e.value;
    console.log(e.value)
    this.calendarEvents = this.tempEvents;
    console.log(this.calendarEvents);
    this.calendarEvents.forEach(function (element, index) {
      if (this.filterOptions !== "all" && this.filterOptions.toLowerCase() !== element.groupId) {
        this.filterEvent(element);
      }
    }, this);

  }
  filterEvent(element) {
    this.calendarEvents = this.calendarEvents.filter(item => item !== element);
  }
  
  createContactForm(calendar): FormGroup {
    return this.fb.group({
      id: [calendar.id],
      title: [
        calendar.title,
        [Validators.required, Validators.pattern('[a-zA-Z]+([a-zA-Z ]+)*')]
      ],
      category: [calendar.category],
      startDate: [calendar.startDate,
      [Validators.required]
      ],
      endDate: [calendar.endDate,
      [Validators.required]
      ],
      details: [
        calendar.details,
        [Validators.required, Validators.pattern('[a-zA-Z]+([a-zA-Z ]+)*')]
      ],
    });
  }

  addNewEvent() {

    const dialogRef = this.dialog.open(FormDialogComponent, {
      data: {
        calendar: this.calendar,
        action: 'add',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {

      if (result === "submit") {
        this.calendarData = this.calendarService.getDialogData();
        this.calendarEvents = this.calendarEvents.concat({ // add new event data. must create new array
          id: this.calendarData.id,
          title: this.calendarData.title,
          start: this.calendarData.startDate,
          end: this.calendarData.endDate,
          className: this.calendarData.category,
          groupId: this.calendarData.category,
          details: this.calendarData.details,
        })
        this.addCusForm.reset();
        this.showNotification(
          'snackbar-success',
          'Add Record Successfully...!!!',
          'bottom',
          'center'
        );
      }
    });
  }
  eventClick(row) {
    const calendarData: any = {
      id: row.event.id,
      title: row.event.title,
      category: row.event.groupId,
      startDate: row.event.start,
      endDate: row.event.end,
      details: row.event.extendedProps.details
    };


    const dialogRef = this.dialog.open(FormDialogComponent, {
      data: {
        calendar: calendarData,
        action: 'edit',
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result === "submit") {
        this.calendarData = this.calendarService.getDialogData();
        this.calendarEvents.forEach(function (element, index) {
          if (this.calendarData.id === element.id) {
            this.editEvent(index, this.calendarData);
          }
        }, this);
        this.showNotification(
          'black',
          'Edit Record Successfully...!!!',
          'bottom',
          'center'
        );
        this.addCusForm.reset();
      } else if (result === "delete") {
        this.calendarData = this.calendarService.getDialogData();
        this.calendarEvents.forEach(function (element, index) {
          if (this.calendarData.id === element.id) {
            this.filterEvent(element);
          }
        }, this);
        this.showNotification(
          'snackbar-danger',
          'Delete Record Successfully...!!!',
          'bottom',
          'center'
        );
      }
    });
  }
  editEvent(eventIndex, calendarData) {
    const calendarEvents = this.calendarEvents.slice();
    const singleEvent = Object.assign({}, calendarEvents[eventIndex]);
    singleEvent.id = calendarData.id;
    singleEvent.title = calendarData.title;
    singleEvent.start = calendarData.startDate;
    singleEvent.end = calendarData.endDate;
    singleEvent.className = this.getClassNameValue(calendarData.category);
    singleEvent.groupId = calendarData.category;
    singleEvent.details = calendarData.details;
    calendarEvents[eventIndex] = singleEvent;
    this.calendarEvents = calendarEvents; // reassign the array
  }
  handleEventRender(info) {
    // console.log(info)
    // this.todaysEvents = this.todaysEvents.concat(info);
  }
  
  submit() {
    // emppty stuff
  }
  onNoClick(): void {
  }
  showNotification(colorName, text, placementFrom, placementAlign) {
    this.snackBar.open(text, '', {
      duration: 2000,
      verticalPosition: placementFrom,
      horizontalPosition: placementAlign,
      panelClass: colorName,
    });
  }
  getClassNameValue(category) {
    let className: string;

    if (category === "Matematyka")
      className = "fc-event-success"
    else if (category === "Plastyka")
      className = "fc-event-warning"
    else if (category === "important")
      className = "fc-event-primary"
    else if (category === "travel")
      className = "fc-event-danger"
    else if (category === "friends")
      className = "fc-event-info"

    return className;
  }
}

