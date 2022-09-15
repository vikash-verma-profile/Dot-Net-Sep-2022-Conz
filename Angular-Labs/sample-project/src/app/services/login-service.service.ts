import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  _loginUrl="https://localhost:44354/api/login";
  _registerUrl="https://localhost:44354/api/register";
  constructor(private http:HttpClient) { }

  loginUser(login:any){
    return this.http.post<any>(this._loginUrl,login);
  }
}
