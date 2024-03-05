import { Component, OnInit, input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Note } from './note';
import { Tage } from '../tage/tage';
import { Reminder } from '../reminder/reminder';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrl: './note.component.css'
})
export class NoteComponent implements OnInit {
  private url1 = 'https://localhost:7156/api/Tage';
  private url = 'https://localhost:7156/api/Note';
  public note: Note = new Note();
  public notes: Note[] = [];
  dateTime = Date;
  tableMode: boolean = true;
  public tage: Tage = new Tage();
  public tages: Tage[] = [];
  public reminder: Reminder = new Reminder();
  
  constructor(private http: HttpClient) { }
  
  ngOnInit() {
    this.getNotes();
    
  }

  form = new FormGroup({
    header: new FormControl('', [Validators.required, Validators.minLength(4)]),
    description: new FormControl('', [Validators.required, Validators.minLength(4)]),
  });

  get f() {
    return this.form.controls;
  }

  submit() {
    console.log(this.form.value);
  }
   
  // получаем данные через сервис
  getTages() {
    this.http.get<Tage[]>(this.url1).subscribe(
      (result) => {
        this.tages = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  
  // получаем данные через сервис
  getNotes() {
    this.http.get<Note[]>(this.url).subscribe(
      (result) => {
        this.notes = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  getNote(noteId: number) {
    return this.http.get(this.url + '/' + noteId);
  }

  updateNote(note: Note) {
    return this.http.put(this.url, this.note);
  }

  // сохранение данных  
  save() {    
    if (this.note.noteId == null) {
      this.http.post(this.url, this.note, { observe: 'response' })
        .subscribe(data => this.getNotes());
    } else {
      this.http.put(this.url, this.note)
        .subscribe(data => this.getNotes());
    }
    this.cancel();
  }
  editNote(p: Note) {
    this.getTages();
    this.note = p;
  }
  cancel() {
    this.note = new Note;
    this.tableMode = true;
  }
  delete(p: Note) {
    this.http.delete(this.url + '/' + p.noteId)
      .subscribe(data => this.getNotes());
  }

  add() {
    this.getTages();
    this.cancel();
    this.tableMode = false;
  }
}
