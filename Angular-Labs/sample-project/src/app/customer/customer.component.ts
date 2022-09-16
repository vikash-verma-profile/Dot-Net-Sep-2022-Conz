import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Customer } from './customer.model';

@Component({
  templateUrl: './customer.component.html'
})
export class CustomerComponent implements OnInit {

  ngOnInit(): void {
    this.GetDataFromServer();
  }

  Success(input: any) {
    console.log(input);
    this.CustomerModels = input;
  }
  constructor(private http: HttpClient) {

  }

  GetDataFromServer() {
    this.http.get("https://localhost:44354/api/Customer").subscribe(res => this.Success(res), res => console.log(res));

  }
  title = 'sample-project';
  imageURL = "././assets/image.jpg";
  isEdit = false;

  CustomerModel: Customer = new Customer();
  CustomerModels: Array<Customer> = new Array<Customer>();
  Add() {
    debugger;
    // console.log('HI');
    // alert('HI');

    // this.CustomerModels.push(this.CustomerModel);
    // console.log(this.CustomerModels);
    var customerdto = {
      customerCode: this.CustomerModel.customerCode,
      customerName: this.CustomerModel.customerName,
      customerAmount: this.CustomerModel.customerAmount
    };
    if (this.isEdit) {
      this.http.put("https://localhost:44354/api/Customer", customerdto).subscribe(res => this.PostSuccess(res), res => console.log(res))
    }
    else {
      this.http.post("https://localhost:44354/api/Customer", customerdto).subscribe(res => this.PostSuccess(res), res => console.log(res))
    }

    this.CustomerModel = new Customer();
  }
  PostSuccess(input: any) {
    this.GetDataFromServer();
  }
  EditCustomer(input: any) {
    debugger;
    this.isEdit = true;
    this.CustomerModel = input;
  }
  DeleteCustomer(input: any) {
    this.http.delete("https://localhost:44354/api/Customer?id=" + input.id).subscribe(res => this.PostSuccess(res), res => console.log(res));
  }

  hasError(typeofValidator:string,controlname:string):Boolean{
    return this.CustomerModel.formCustomerGroup.controls[controlname].hasError(typeofValidator);
  }
}
