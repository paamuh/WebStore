using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore
{
    class OrderController
    {
        public List<Order> _orders { get; set; }

        public void AddOrder(int customerId, string customerName, int orderLineId)
        {
            Order newOrder = new Order(customerId, customerName, orderLineId);

            _orders.Add(newOrder);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public void addRandomOrders()
        {
            Order newOrder0 = new Order(1,"Per", 1);
            Order newOrder1 = new Order(2, "Pål", 2);
            Order newOrder2 = new Order(3, "Espen", 1);
            Order newOrder3 = new Order(4, "Askeladd", 1);
            Order newOrder4 = new Order(5, "Turid", 1);
            Order newOrder5 = new Order(6, "Kar", 1);


            List<Order> orders = new List<Order>();

            orders.Add(newOrder0);
            orders.Add(newOrder1);
            orders.Add(newOrder2);
            orders.Add(newOrder3);
            orders.Add(newOrder4);
            orders.Add(newOrder5);

            newOrder0.addOrderLine(1, 199, 1, "Monitor", 1);
            newOrder0.addOrderLine(1, 199, 1, "Sekk", 2);
            newOrder0.addOrderLine(3, 499, 2, "dnb", 3);
            


            this._orders = orders;
            
        }
    }
}
