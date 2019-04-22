using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore
{
    class OrderLine
    {
        public int Quantity { get; set; }
        public double Price { get; set; }

        public int OrderLineId { get; set; }

        public string ProductName { get; set; }

        public int ProductId { get; set; }

        public OrderLine(int quantity, double price, int orderLineId, string productName, int productId)
        {
            this.Quantity = quantity;
            this.Price = price;
            this.OrderLineId = orderLineId;
            this.ProductName = productName;
            this.ProductId = productId;

        }
    }
}
