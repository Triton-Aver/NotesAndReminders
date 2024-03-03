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
  getTage(tagId: number) {
    return this.http.get(this.url + '/' + tagId);
  }

  updateTage(tage: Tage) {
    return this.http.put(this.url, tage);
  }

  // сохранение данных  
  save() {
    if (this.tage.tagId == null) {
      this.http.post(this.url, this.tage, { observe: 'response' })
        .subscribe(data => this.getTages());
    } else {
      this.http.put(this.url, this.tage)
        .subscribe(data => this.getTages());
    }
    this.cancel();
  }
  editTage(p: Tage) {
    this.tage = p;
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
