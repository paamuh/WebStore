using System;
using System.Collections.Generic;

namespace WebStore
{
    class Program
    {
        static void Main(string[] args)
        {

            Order order = new Order();
            OrderController orderController = new OrderController();


            orderController.addRandomOrders();

            
            

            
            
            List<Order> allOrders = orderController.GetOrders();

            Order order1 = allOrders[0];

            List<OrderLine> ordre = order1.OrderLines;

            var j = ordre[0];

            Console.WriteLine(j.ProductName);
            /*
            foreach (var i in allOrders)
                Console.WriteLine(i.CalculateOrderTotal(i.));
            */

            //Console.WriteLine(order.CalculateOrderTotal(1));
            
        }
    }
}
