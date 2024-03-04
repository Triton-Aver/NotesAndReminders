import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Tage } from './tage/tage';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AllService {
  private url = 'https://localhost:7156/api/Tage';
  public tage: Tage = new Tage();
  public tages: Tage[] = [];
  tableMode: boolean = true;
  constructor(private http: HttpClient) { }

  
  // получаем данные через сервис
  getTages() {
    return this.http.get<Tage[]>(this.url).subscribe(
      (result: Tage[]) => {
        this.tages = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
  
}
