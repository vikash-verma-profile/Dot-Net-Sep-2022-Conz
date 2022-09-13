import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Customer } from './customer.model';

@Component({
  templateUrl: './customer.component.html'
})
export class CustomerComponent implements OnInit {

  ngOnInit(): void {
   
    this.http.get("http://localhost:3000/customers").subscribe(res=>this.Success(res),res=>console.log(res));
  }

  Success(input:any){
    this.CustomerModels=input;
  }
  constructor(private http:HttpClient) {

  }
  title = 'sample-project';
  imageURL = "././assets/image.jpg";

  CustomerModel: Customer = new Customer();
  CustomerModels: Array<Customer> = new Array<Customer>();
  Add() {
    debugger;
    // console.log('HI');
    // alert('HI');

    this.CustomerModels.push(this.CustomerModel);
    console.log(this.CustomerModels);
    this.CustomerModel = new Customer();
  }

  EditCustomer(input: any) {
    debugger;
    this.CustomerModel = input;
  }
}
