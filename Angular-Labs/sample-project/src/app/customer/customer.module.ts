import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {RouterModule} from '@angular/router';
import { customerroutes } from '../routing/customerroutes';
import { GridUIModule } from '../utilites/grid-ui/grid-ui.module';
import { CustomerComponent } from './customer.component';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import { LoginServiceService } from '../services/login-service.service';
import { TokenInterceptorService } from '../services/tokenInceptorservice';

@NgModule({
  declarations: [
    CustomerComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(customerroutes),
    GridUIModule,
    HttpClientModule
  ],
  providers: [LoginServiceService,{provide:HTTP_INTERCEPTORS,useClass:TokenInterceptorService,multi:true}],
  bootstrap: [CustomerComponent]
})
export class CustomerModule { }
