import { Component } from '@angular/core';
import { Customer } from './app.customerModel';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'sample-project';

  //object of customer type
  CustomerModel:Customer=new Customer();

  showCustomer(){
    console.log('HI');
    console.log(this.CustomerModel.CustomerName);
  }
}
