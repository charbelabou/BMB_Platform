import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {LoginPage} from './authentication/login-page/login-page';
import {OrdersPage} from './orders/orders-page/orders-page';

const routes: Routes = [
  {path: 'login', component: LoginPage},
  {path: 'orders', component: OrdersPage},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
