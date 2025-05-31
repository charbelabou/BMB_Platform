// src/app/orders/orders.module.ts

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersPage } from './orders-page/orders-page';
import { OrdersTable } from './components/orders-table/orders-table';

// Import the Material *modules* (not the individual classes)
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    OrdersPage,
    OrdersTable,
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatButtonModule,
  ]
})
export class OrdersModule { }
