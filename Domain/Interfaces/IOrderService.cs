using Domain.Entities;
using Domain.Entities.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderService
    {
        public ServiceResult<int> AddToCart(OrderDto orderDto);
        public ServiceResult<int> DeleteFromCart(string orderID);
        public ServiceResult<List<Order>> GetOrders(string CartID);
    }
}
