import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from "@ng-select/ng-select";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { NoteComponent } from './note/note.component';
import { AppComponent } from './app.component';
import { TageComponent } from './tage/tage.component';
import { ReminderComponent } from './reminder/reminder.component';


@NgModule({
  declarations: [
    AppComponent, NoteComponent, TageComponent, ReminderComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, NgSelectModule,
    FormsModule, ReactiveFormsModule, NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent, NoteComponent, TageComponent, ReminderComponent]
})
export class AppModule { }
