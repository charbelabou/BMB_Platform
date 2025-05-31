import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Order} from '../../../shared/models/order';
import {environment} from '../../../environments/environment';


@Injectable({ providedIn: 'root' })
export class OrderService {
  private apiUrl = 'api/orders';

  constructor(private http: HttpClient) {}

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${environment.gateway}/${this.apiUrl}`);
  }

  createOrder(order: Order): Observable<number> {
    return this.http.post<number>(`${environment.gateway}/${this.apiUrl}`,order);
  }

  updateOrder(order: Order): Observable<void> {
    return this.http.put<void>(`${environment.gateway}/${this.apiUrl}/${order.id}`, order);
  }

  deleteOrder(id: number): Observable<void> {
    return this.http.delete<void>(`${environment.gateway}/${this.apiUrl}/${id}`);
  }
}
