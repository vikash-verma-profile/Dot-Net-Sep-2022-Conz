import { Component, OnInit } from '@angular/core';
import { LoginServiceService } from '../services/login-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './master.component.html'
})
export class MasterComponent implements OnInit {

  constructor(private _auth:LoginServiceService) { }

  ngOnInit(): void {
  }

  LoggedIn(Input:boolean):boolean{
    if(Input){
      return this._auth.logginIn();
    }
    else{
      return !this._auth.logginIn();
    }
  }
  Logout(){
    this._auth.logoutUser();
    
  }
}
