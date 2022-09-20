import { DummyComponent } from "../dummy/dummy.component";
import { HomeComponent } from "../home/home.component";
import { LoginComponent } from "../login/login.component";
import { RegisterComponent } from "../register/register.component";

export const Mainroutes = [
    { path: '', component: HomeComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'customer', loadChildren: () => import('../customer/customer.module').then(m => m.CustomerModule) },
    { path: 'supplier', loadChildren: () => import('../supplier/supplier.module').then(m => m.SupplierModule) },
    { path: 'home', component: HomeComponent },
    {path:'dummy',component:DummyComponent}
];
