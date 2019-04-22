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
        public Order(int customerId, string customerName, int orderLineId)
        {
            this.OrderId = Interlocked.Increment(ref globalOrderId);
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.TotalPrice = 0;
            //this.TotalPrice = CalculateOrderTotal(orderLineId);
            
        }

        public void addOrderLine(int quantity, double price, int orderLineId, string productName, int productId)
        {
            List<OrderLine> orderLines = new List<OrderLine>();
            OrderLine newOrderLine = new OrderLine(quantity, price,orderLineId, productName, productId);

            OrderLines = orderLines;
        }





        /*
        public List<OrderLine> GetOrderLines()
        {
            List<OrderLine> orderLines = new List<OrderLine>();

            //Hardcode some orders
            OrderLine mousePad = new OrderLine();
            mousePad.Quantity = 1;
            mousePad.Price = 99.99;
            mousePad.OrderLineId = 1;
            mousePad.ProductName = "Mousepad";
            mousePad.ProductId = 1;

            orderLines.Add(mousePad);

            OrderLine monitor = new OrderLine();
            monitor.Quantity = 2;
            monitor.Price = 2399.99;
            monitor.OrderLineId = 1;
            monitor.ProductName = "Benq XL2410T";
            monitor.ProductId = 2;

            orderLines.Add(monitor);

            //second orderline

            OrderLine keyboard = new OrderLine();
            keyboard.Quantity = 10;
            keyboard.Price = 499.99;
            keyboard.OrderLineId = 2;
            keyboard.ProductName = "Razer Chroma";
            keyboard.ProductId = 3;

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
        

        //Calculates total price of an order, needs to insert orderLineId to know wich
        // orderlines this order contain.
        public double CalculateOrderTotal(int orderLineId)
        {
            double totalPrice = 0;

            
            List<OrderLine> orderLines = GetOrderLinesById(orderLineId);

            

            foreach(var i in orderLines)
            {  
                totalPrice = (i.Quantity * i.Price) + totalPrice; 
            }

            return totalPrice;
        }

        */
    }
}
