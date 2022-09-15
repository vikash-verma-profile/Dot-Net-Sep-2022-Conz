import { Component, OnInit } from '@angular/core';
import { UserData } from '../models/userdata';
import { LoginServiceService } from '../services/login-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  constructor(private _service:LoginServiceService) { }

  UserDataModel:UserData=new UserData();
  ngOnInit(): void {
  }

  loginUser(){
    this._service.loginUser(this.UserDataModel).subscribe(res=>{
      console.log('Hi You are able to login');
      alert('Hi');
      localStorage.setItem('token',res.token);
    },res=>console.log(res));
  }

}
