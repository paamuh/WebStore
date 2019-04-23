using System;
using System.Collections.Generic;

namespace WebStore
{
    class Program
    {
        static void Main(string[] args)
        {

            
            
            OrderController orderController = new OrderController();

            var order0 = orderController.AddOrder(1, "Thorbjørn");
            order0.addOrderLine(2, 199, 1, "PC", 1);

            var posOrder0 = orderController.AddPosOrder(38, 2, "Per");
            posOrder0.Order.addOrderLine(3, 200, 2, "Flaske", 2);
            posOrder0.Order.addOrderLine(1, 199, 1, "PC", 1);

            var posOrder1 = orderController.AddPosOrder(22, 3, "Håkon");
            posOrder1.Order.addOrderLine(1, 100, 3, "Tv", 3);

            Console.WriteLine("Finds order by CustomerId and show the totalprice");
            List<Order> testGetOrderById = orderController.GetOrderByCustomerId(1);
            Console.WriteLine(testGetOrderById[0].TotalPrice);

            Console.WriteLine("Show the name of customers that have orders with ProductId 1:  ");
            List<Order> testGetOrdersByProductId = orderController.GetOrdersByProductId(1);
            Console.WriteLine(testGetOrdersByProductId[0].CustomerName);
            Console.WriteLine(testGetOrdersByProductId[1].CustomerName);

            Console.Write("Calculates total of order 1: ");
            Console.WriteLine(orderController.CalculateOrderTotalByOrderId(1));

            Console.WriteLine("Print out TotalPrice of order0, posOrder0, and posOrder1");
            Console.WriteLine(order0.TotalPrice);
            Console.WriteLine(posOrder0.Order.TotalPrice);
            Console.WriteLine(posOrder1.Order.TotalPrice);

            Console.ReadKey();
        }
    }
}
