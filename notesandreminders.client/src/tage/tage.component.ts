import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tage } from './tage';

@Component({
  selector: 'app-tage',
  templateUrl: './tage.component.html',
  styleUrl: './tage.component.css'
})
export class TageComponent implements OnInit {
  private url = 'https://localhost:7156/api/Tage';
  public tage: Tage = new Tage();
  public tages: Tage[] = [];
  tableMode: boolean = true;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getTages();
  }  

  // получаем данные через сервис
  getTages() {
    this.http.get<Tage[]>(this.url).subscribe(
      (result) => {
        this.tages = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  
  // сохранение данных  
  save() {
    if (this.tage.tagId == null) {
      this.http.post(this.url, this.tage, { observe: 'response' })
        .subscribe(data => this.getTages());
    } 
    this.cancel();
  }  
  cancel() {
    this.tage = new Tage;
    this.tableMode = true;
  }

  delete(p: Tage) {
    this.http.delete(this.url + '/' + p.tagId)
      .subscribe(data => this.getTages());
  }

  add() {
    this.cancel();
    this.tableMode = false;
  }
}
