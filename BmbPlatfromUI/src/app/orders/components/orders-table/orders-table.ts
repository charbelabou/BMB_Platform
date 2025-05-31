import {Component, OnInit} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {Order} from '../../../../shared/models/order';
import {OrderService} from '../../services/orders-service';

@Component({
  selector: 'app-orders-table',
  standalone: false,
  templateUrl: './orders-table.html',
  styleUrl: './orders-table.scss'
})
export class OrdersTable implements OnInit{
  displayedColumns: string[] = ['id', 'orderDate', 'total', 'clientId'];
  dataSource: Order[] = [];

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.orderService.getOrders().subscribe({
      next: (orders) => {
        this.dataSource = orders;
      },
      error: (err) => {
        console.error('Failed to load orders:', err);
      }
    });
  }
}
