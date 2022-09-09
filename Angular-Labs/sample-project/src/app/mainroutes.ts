import { CustomerComponent } from "./customer/customer.component";
import { HomeComponent } from "./home/home.component";
import { SupplierComponent } from "./supplier/supplier.component";

export const Mainroutes = [
    { path: '', component: HomeComponent },
    { path: 'customer', component: CustomerComponent },
    { path: 'supplier', component: SupplierComponent },
    { path: 'home', component: HomeComponent },
];
