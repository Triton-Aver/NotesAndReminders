import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from "@ng-select/ng-select"; 
import { NoteComponent } from './note.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [NoteComponent],
  imports: [
    BrowserModule, HttpClientModule,
    FormsModule, NgSelectModule, NgbModule, ReactiveFormsModule
  ],
    providers: [],
  bootstrap: [NoteComponent]
})
export class NoteModule { }
