using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        public int AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public int DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrdersByCartID()
        {
            throw new NotImplementedException();
        }

        public int UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
