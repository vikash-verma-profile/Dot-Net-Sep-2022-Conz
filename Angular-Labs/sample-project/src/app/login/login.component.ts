import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserData } from '../models/userdata';
import { LoginServiceService } from '../services/login-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  constructor(private _service:LoginServiceService,private _router:Router) { }
  ErrorMessage:any='';
  UserDataModel:UserData=new UserData();
  ngOnInit(): void {
  }

  loginUser(){
    this._service.loginUser(this.UserDataModel).subscribe(res=>{
     
      localStorage.setItem('token',res.token);
      this._router.navigate(['dummy']);
    },res=>
    {
      console.log(res);
      this.ErrorMessage="Some error have occured";
      document.getElementById('btnErrorMsg')?.click();
    });
  }

}
