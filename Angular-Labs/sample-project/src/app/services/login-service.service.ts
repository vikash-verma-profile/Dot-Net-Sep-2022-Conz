import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  _loginUrl="https://localhost:44354/api/login/login-user";
  _registerUrl="https://localhost:44354/api/login/register-user";
  constructor(private http:HttpClient,private _router:Router) { }

  loginUser(login:any){
    return this.http.post<any>(this._loginUrl,login);
  }
  getToken(){
    return localStorage.getItem('token');
  }
  logginIn(){
    return !!localStorage.getItem('token');
  }

  logoutUser(){
    localStorage.removeItem('token');
    this._router.navigate(['']);
  }
}
