﻿namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}