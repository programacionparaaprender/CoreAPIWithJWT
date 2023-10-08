import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TarjetaCredito } from '../models/tarjetacredito';
import { Responsetarjeta } from '../models/responsetarjeta';
import { Usertoken } from '../models/usertoken';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  myApiUrl = "/api/account/";
  KEYTOKEN = "KEYTOKEN";
  constructor(private http: HttpClient) {
    
  }

  public login(user: User):Observable<Usertoken> {
    return this.http.post<Usertoken>(this.myApiUrl + "/token", user);
  }

  public getToken(): string {
    const token:string | null = localStorage.getItem(this.KEYTOKEN);
    if(token != null)
      return token;
    return "";
  }

  getListTarjetas(): Observable<Responsetarjeta>{
    return this.http.get<Responsetarjeta>(this.myApiUrl);
  }

  deleteTarjeta(id: number): Observable<TarjetaCredito> {
    return this.http.delete<any>(this.myApiUrl + String(id));
  }
  
  saveTarjeta(tarjeta: any): Observable<TarjetaCredito> {
      return this.http.post<TarjetaCredito>(this.myApiUrl, tarjeta);
  }

  updateTarjeta(tarjeta: TarjetaCredito, id: number): Observable<any> {
    return this.http.put<any>(this.myApiUrl + `${id}`, tarjeta);
  }
}
