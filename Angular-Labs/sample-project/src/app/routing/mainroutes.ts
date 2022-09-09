import { HomeComponent } from "../home/home.component";

export const Mainroutes = [
    { path: '', component: HomeComponent },
    { path: 'customer', loadChildren: () => import('../customer/customer.module').then(m => m.CustomerModule) },
    { path: 'supplier', loadChildren: () => import('../supplier/supplier.module').then(m => m.SupplierModule) },
    { path: 'home', component: HomeComponent },
];
