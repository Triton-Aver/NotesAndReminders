import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from "@ng-select/ng-select"; 

import { ReminderComponent } from './reminder.component';

@NgModule({
  declarations: [ReminderComponent],
  imports: [
    BrowserModule, HttpClientModule,
    FormsModule, NgSelectModule
  ],
  providers: [],
  bootstrap: [ReminderComponent]
})

export class ReminderModule { }



