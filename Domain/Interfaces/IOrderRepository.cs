using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IOrderRepository
    {
        public int AddOrder(Order order);
        public int UpdateOrder(Order order);
        public int DeleteOrder(string orderId);
        public List<Order> GetOrdersByCartID(string cartID);
    }
}

