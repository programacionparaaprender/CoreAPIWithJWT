import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseMenu } from '../models/responsemenu';
import { Responsetarjeta } from '../models/responsetarjeta';


@Injectable({
  providedIn: 'root'
})
export class MenuService {
  myAppUrl = "https://localhost:44372/";
  myAppUrl2 = "https://localhost:5001/";
  myApiUrl = "/api/menu/";
  KEYTOKEN = "KEYTOKEN";
  constructor(private http: HttpClient) {

  }

  getMenus(): Observable<ResponseMenu> {
    return this.http.get<ResponseMenu>(this.myApiUrl);
  }

}
