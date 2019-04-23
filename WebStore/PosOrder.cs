using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore
{
    class PosOrder
    {
        public int PosId;

        public Order Order;

        public PosOrder(int posId, int customerId, string customerName)
        {
            this.Order = new Order(customerId, customerName);
            
            this.PosId = posId;
        }
    }
}
