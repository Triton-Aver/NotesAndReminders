import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { TageComponent } from './tage.component';

@NgModule({
  declarations: [
    TageComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [TageComponent]
  
})
export class TageModule { }
