import { Component, OnInit } from '@angular/core';
import { Supplier } from './supplier.model';

@Component({
  selector: 'app-supplier',
  templateUrl: './supplier.component.html',
  styleUrls: ['./supplier.component.css']
})
export class SupplierComponent {

  SupplierModel: Supplier = new Supplier();
  SupplierModels: Array<Supplier> = new Array<Supplier>();
  Add() {
    debugger;
    // console.log('HI');
    // alert('HI');

    this.SupplierModels.push(this.SupplierModel);
    console.log(this.SupplierModels);
    this.SupplierModel = new Supplier();
  }

}
