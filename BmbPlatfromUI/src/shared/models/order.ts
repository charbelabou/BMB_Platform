export interface Order {
  id: number;
  productId: number;
  quantity: number;
  total: number;
  clientId: number;
  orderDate: string;
}
