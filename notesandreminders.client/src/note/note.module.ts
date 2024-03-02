import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { NoteComponent } from './note.component';

@NgModule({
  declarations: [NoteComponent],
  imports: [
    BrowserModule, HttpClientModule,
    FormsModule
  ],
    providers: [],
    bootstrap: [NoteComponent]
})
export class NoteModule { }
