import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {RouterModule} from '@angular/router';
import { customerroutes } from '../routing/customerroutes';
import { GridUIModule } from '../utilites/grid-ui/grid-ui.module';
import { CustomerComponent } from './customer.component';
import {HttpClientModule} from '@angular/common/http'

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
  providers: [],
  bootstrap: [CustomerComponent]
})
export class CustomerModule { }
