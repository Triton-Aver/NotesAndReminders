var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Note } from './note';
let NoteComponent = class NoteComponent {
    dataService;
    note = new Note(); //изменяемый заметки
    notes; //массив заметок
    tableMode = true; //табличный режим
    constructor(dataService) {
        this.dataService = dataService;
    }
    ngOnInit() {
        this.loadNotes(); // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadNotes() {
        this.dataService.getNotes()
            .subscribe((data) => this.notes = data);
    }
    // сохранение данных
    save() {
        if (this.note.noteId == null) {
            this.dataService.createNote(this.note)
                .subscribe((data) => {
                console.log(data);
                this.notes.push(data.body);
            });
        }
        else {
            this.dataService.updateNote(this.note)
                .subscribe(data => this.loadNotes());
        }
        this.cancel();
    }
    editNote(p) {
        this.note = p;
    }
    cancel() {
        this.note = new Note();
        this.tableMode = true;
    }
    delete(p) {
        this.dataService.deleteNote(p.noteId)
            .subscribe(data => this.loadNotes());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
};
NoteComponent = __decorate([
    Component({
        selector: 'note',
        templateUrl: './note.component.html',
        providers: [DataService],
        styleUrls: ['./note.component.css']
    })
], NoteComponent);
export { NoteComponent };
//# sourceMappingURL=note.component.js.map