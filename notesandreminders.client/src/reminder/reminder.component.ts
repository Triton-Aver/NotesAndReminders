import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Reminder } from './reminder';
import { Note } from '../note/note';

@Component({
  selector: 'app-reminder',
  templateUrl: './reminder.component.html',
  styleUrl: './reminder.component.css'
})
export class ReminderComponent implements OnInit {

  private url = 'https://localhost:7156/api/Reminder';
  private url1 = 'https://localhost:7156/api/Note';
  public reminder: Reminder = new Reminder();
  public reminders: Reminder[] = [];
  public notes: Note[] = [];
  tableMode: boolean = true;
  constructor(private http: HttpClient) { }  

  ngOnInit() {
    this.getReminders();
  }

  // получаем данные через сервис
  getNotes() {
    this.http.get<Note[]>(this.url1).subscribe(
      (result) => {
        this.notes = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  // получаем данные через сервис
  getReminders() {
    this.http.get<Reminder[]>(this.url).subscribe(
      (result) => {
        this.reminders = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }    
  // сохранение данных  
  save() {
    if(this.reminder.reminderId == null) {
      this.http.post(this.url, this.reminder, { observe: 'response' })
        .subscribe(data => this.getReminders());
    } 
    this.cancel();
  }  
  cancel() {
    this.reminder = new Reminder;
    this.tableMode = true;
  }  
  add() {
    this.getNotes()
    this.cancel();
    this.tableMode = false;
  }
}
