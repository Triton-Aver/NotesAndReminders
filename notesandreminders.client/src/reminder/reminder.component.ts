import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Reminder } from './reminder';

@Component({
  selector: 'app-reminder',
  templateUrl: './reminder.component.html',
  styleUrl: './reminder.component.css'
})
export class ReminderComponent implements OnInit {

  private url = 'https://localhost:7156/api/Reminder';
  public reminder: Reminder = new Reminder();
  public reminders: Reminder[] = [];
  tableMode: boolean = true;
  constructor(private http: HttpClient) { }  

  ngOnInit() {
    this.getReminders();
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
  getReminder(reminderId: number) {
    return this.http.get(this.url + '/' + reminderId);
  }

  updateReminder(reminder: Reminder) {
    return this.http.put(this.url, Reminder);
  }

  // сохранение данных  
  save() {
    if (this.reminder.reminderId == null) {
      this.http.post(this.url, this.reminder, { observe: 'response' })
        .subscribe(data => this.getReminders());
    } else {
      this.http.put(this.url, this.reminder)
        .subscribe(data => this.getReminders());
    }
    this.cancel();
  }
  editReminder(p: Reminder) {
    this.reminder = p;
  }
  cancel() {
    this.reminder = new Reminder;
    this.tableMode = true;
  }
  delete(p: Reminder) {
    this.http.delete(this.url + '/' + p.reminderId)
      .subscribe(data => this.getReminders());
  }

  add() {
    this.cancel();
    this.tableMode = false;
  }
}
