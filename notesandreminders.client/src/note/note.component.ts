import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Note } from './note';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrl: './note.component.css'
})
export class NoteComponent implements OnInit {
  private url = 'https://localhost:7156/api/Note';
  public note: Note = new Note();
  public notes: Note[] = [];
  
  tableMode: boolean = true;
  constructor(private http: HttpClient) { }

  title = "geeksforgeeks-multiSelect";

  cars = [
    { id: 6, name: "базовый" },
    { id: 5, name: "работа" },    
  ];

  selected = [{ id: 6, name: "базовый" }]; 


  ngOnInit() {
    this.getNotes();
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
    return this.http.put(this.url, note);
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
    this.cancel();
    this.tableMode = false;
  }
}
