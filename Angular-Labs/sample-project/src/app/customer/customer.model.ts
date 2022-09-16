import { NgForm,FormGroup,Validators,FormBuilder,FormControl } from "@angular/forms";

export class Customer{
    customerCode:string='';
    customerName:string='';
    customerAmount:number=0;
    id:number=0;
    formCustomerGroup:FormGroup;//Create

    constructor(){
        var _builder=new FormBuilder();
        this.formCustomerGroup=_builder.group({});
        this.formCustomerGroup.addControl("CustomerNameControl",new FormControl('',Validators.required));
        this.formCustomerGroup.addControl("CustomerCodeControl",new FormControl('',Validators.required));
        this.formCustomerGroup.addControl("CustomerAmountControl",new FormControl('',Validators.required));
    }
}