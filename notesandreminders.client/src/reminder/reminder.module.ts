import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { ReminderComponent } from './reminder.component';

@NgModule({
  declarations: [ReminderComponent],
  imports: [
    BrowserModule, HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [ReminderComponent]
})

export class ReminderModule { }



