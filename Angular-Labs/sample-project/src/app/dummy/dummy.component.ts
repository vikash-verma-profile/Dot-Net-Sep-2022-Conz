import { Component, OnInit } from '@angular/core';
import { LoginServiceService } from '../services/login-service.service';
import { JwtHelperService } from '@auth0/angular-jwt';


@Component({
  selector: 'app-dummy',
  templateUrl: './dummy.component.html',
  styleUrls: ['./dummy.component.css']
})
export class DummyComponent implements OnInit {

  constructor(private jwt: JwtHelperService, private _auth: LoginServiceService) { }

  name='';
  ngOnInit(): void {
    this.name=this.jwt.decodeToken(this._auth.getToken()?.toString()).unique_name;
    console.log(this.jwt.decodeToken(this._auth.getToken()?.toString()));
    console.log(this.name);
  }

}
