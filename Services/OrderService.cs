using Domain.Contracts;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderReository;
        public OrderService(IOrderRepository orderRepository )
        {
            _orderReository = orderRepository;
        }
        
    }
}
