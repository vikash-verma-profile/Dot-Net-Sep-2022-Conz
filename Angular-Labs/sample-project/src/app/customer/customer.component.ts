import { Component } from '@angular/core';
import { Customer } from './customer.model';

@Component({
  templateUrl: './customer.component.html'
})
export class CustomerComponent {
  title = 'sample-project';
  imageURL="././assets/image.jpg";

  CustomerModel:Customer=new Customer();
  CustomerModels:Array<Customer>=new Array<Customer>();
  Add(){
    debugger;
    // console.log('HI');
    // alert('HI');
  
    this.CustomerModels.push(this.CustomerModel);
    console.log(this.CustomerModels);
    this.CustomerModel=new Customer();
  }
}
