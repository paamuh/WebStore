using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WebStore
{
    class Order
    {
        
        public int OrderId { get; set; }

        public static int globalOrderId;

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public double TotalPrice { get; set; }

        public List<OrderLine> OrderLines { get; set; }

        public Order()
        {

        }
        public Order(int customerId, string customerName)
        {
            this.OrderId = Interlocked.Increment(ref globalOrderId);
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.TotalPrice = 0; 
            this.OrderLines = new List<OrderLine>();



        }

        public void addOrderLine(int quantity, double price, int orderLineId, string productName, int productId)
        {
            
            OrderLine newOrderLine = new OrderLine(quantity, price,orderLineId, productName, productId);


            OrderLines.Add(newOrderLine);

            //Updates the totalprice for order everytime a new orderLine get added.
            this.TotalPrice = CalculateOrderTotal(this.OrderId);
            
        }




        /*
        
        public List<OrderLine> GetOrderLines()
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            //Hardcode some orders
            OrderLine mousePad = new OrderLine(1, 99.99, 1, "Mousepad", 1);
            OrderLine monitor = new OrderLine(2, 2399.99,2, "Benq XL2410T", 2);
            OrderLine keyboard = new OrderLine(1, 1299.99, 1, "Razer Chroma", 3);

            orderLines.Add(mousePad);
            orderLines.Add(monitor);
            orderLines.Add(keyboard);

            return orderLines;

        }
        
        public List<OrderLine> GetOrderLinesById( int orderLineId)
        {
            List<OrderLine> orderLines = GetOrderLines();
            List<OrderLine> orderLinesById = new List<OrderLine>();

            foreach(var i in orderLines)
            {
                if(i.OrderLineId == orderLineId)
                {
                    orderLinesById.Add(i);
                }
            }

            return orderLinesById;


        }
        */
        

        //Updates the total price of an order.
        private double CalculateOrderTotal(int orderId)
        {
            double totalPrice = 0;


            List<OrderLine> orderLines = this.OrderLines;

            

            foreach(var i in orderLines)
            {  
                totalPrice = (i.Quantity * i.Price) + totalPrice; 
            }

            return totalPrice;
        }

        
    }
}
