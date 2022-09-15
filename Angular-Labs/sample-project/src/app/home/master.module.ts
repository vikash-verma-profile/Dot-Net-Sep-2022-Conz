import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import {RouterModule} from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { MasterComponent } from '../master/master.component';
import { Mainroutes } from '../routing/mainroutes';
import { LoginServiceService } from '../services/login-service.service';
import { HomeComponent } from './home.component';


@NgModule({
  declarations: [
    HomeComponent,
    MasterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(Mainroutes),
    HttpClientModule
  ],
  providers: [LoginServiceService],
  bootstrap: [MasterComponent]
})
export class MasterModule { }
