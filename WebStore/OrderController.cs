using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebStore
{   

    //Made an OrderController, this way all the actions is inside the OrderController.
    class OrderController
    {
        public List<Order> _orders { get; set; }
        public List<PosOrder> _posOrders { get; set; }

        public OrderController()
        {
            _orders = new List<Order>();
            _posOrders = new List<PosOrder>();
        }

        public Order AddOrder(int customerId, string customerName)
        {
            Order newOrder = new Order(customerId, customerName);

            _orders.Add(newOrder);

            return newOrder;
        }

        public PosOrder AddPosOrder(int posId, int customerId, string customerName)
        {
            PosOrder newPosOrder = new PosOrder(posId, customerId, customerName);

            _posOrders.Add(newPosOrder);

            return newPosOrder;
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public Order GetOrderByOrderId(int orderId)
        {
            Order orderFound = new Order();
            foreach (var i in _orders)
                if(i.OrderId == orderId)
                {
                    orderFound = i;
                }
            return orderFound;
        }
        //ikke testet
        public List<Order> GetOrderByCustomerId(int customerId)
        {
            List<Order> ordersFound = new List<Order>();

            foreach (var i in _orders)
                if(i.CustomerId == customerId)
                {
                    ordersFound.Add(i);
                }

            return ordersFound;
        }
        //ikke testet
        public List<Order> GetOrdersByProductId(int productId)
        {
            List<Order> ordersFound = new List<Order>();

            foreach(var i in _orders)
                foreach(var j in i.OrderLines)
                    if(j.ProductId == productId)
                    {
                        ordersFound.Add(i);
                    }

            //A Loop for posOrders also.
            foreach(var i in _posOrders)
                foreach(var j in i.Order.OrderLines)
                    if(j.ProductId == productId)
                    {
                        ordersFound.Add(i.Order);
                    }

            return ordersFound;
        }

        public void addRandomOrders()
        {
            Order newOrder0 = new Order(1,"Per");
            Order newOrder1 = new Order(2, "Pål");
            Order newOrder2 = new Order(3, "Espen");
            Order newOrder3 = new Order(4, "Askeladd");
            Order newOrder4 = new Order(5, "Turid");
            Order newOrder5 = new Order(6, "Kar");


            _orders.Add(newOrder0);
            _orders.Add(newOrder1);
            _orders.Add(newOrder2);
            _orders.Add(newOrder3);
            _orders.Add(newOrder4);
            _orders.Add(newOrder5);

            newOrder0.addOrderLine(1, 199, 1, "Monitor", 1);
            newOrder0.addOrderLine(1, 299, 2, "Sekk", 2);
            newOrder0.addOrderLine(3, 499, 3, "dnb", 3);
            newOrder1.addOrderLine(1, 599.99, 1, "Laptop", 4);
            newOrder1.addOrderLine(2, 799.99, 2, "Waterbottle", 5);

            
        }


        public double CalculateOrderTotalByOrderId(int orderId)
        {
            double totalPrice = 0;

            Order orderFound = GetOrderByOrderId(orderId);


            if(orderFound == null)
            {
                Console.WriteLine("No products found");
                totalPrice = 0;
            }

            foreach (var i in orderFound.OrderLines)
                totalPrice = (i.Quantity * i.Price) + totalPrice;

            return totalPrice;
        }

        
        public Dictionary<string, double> GetTopSellingProducts()
        {
            var topSellingProducts = new Dictionary<string, double>();

            List<OrderLine> copyOfAllOrderLines = new List<OrderLine>();

            

            //Copies over all Orderlines from _orders
            foreach (var i in _orders)
                foreach (var j in i.OrderLines)
                    copyOfAllOrderLines.Add(j);

            //Copies over all OrderLines from _posOrders
            foreach(var i in _posOrders)
                foreach (var j in i.Order.OrderLines)
                    copyOfAllOrderLines.Add(j);

           

            var most = (from i in copyOfAllOrderLines
                        group i by i into grp
                        orderby grp.Count() descending
                        select grp.Key);

            
            

            //Check how much of the item is sold, adds 
            foreach (var e in most)
            {
                int topsoldItemId = e.ProductId;
                int soldItemsCounter = 0;
                foreach (var k in copyOfAllOrderLines)
                {
                    if (k.ProductId == topsoldItemId)
                    {
                        soldItemsCounter += k.Quantity;
                    }
                }
                double totalRevenue = soldItemsCounter * e.Price;
                topSellingProducts.Add(e.ProductName, totalRevenue);
                Console.WriteLine(e.ProductId);
            }
            
            

            return topSellingProducts;

            //My plan was to find the top 5 most used items, count the times they are
            // in the list. Then count * price to get the total the product has sold.
            // Then add items with highest count on top with the total and return it as
            // a dictionary.
        }
        

    }
}
