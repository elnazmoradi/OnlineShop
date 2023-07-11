using Domain.Contracts;
using Domain.Entities;
using Domain.Entities.DtoModels;
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
        private readonly ISocksRepository _socksRepository;
        public OrderService(IOrderRepository orderRepository,ISocksRepository socksRepository )
        {
            _orderReository = orderRepository;
        }

        public ServiceResult<int> AddToCart(OrderDto orderDto)
        {
            var order = new Order
            {
                ID = Guid.NewGuid(),
                CartID = orderDto.CartID,
                SocksID = orderDto.SocksID,
                OrderPrice = _socksRepository.GetSocksByID(orderDto.SocksID).Price * orderDto.SocksNumber,
                SocksNumber = orderDto.SocksNumber
            };
           var result = _orderReository.AddOrder(order);
           if (result > 0)
            {
                return new SuccessfulServiceResult<int>(result);

            }
            else
            {
                return new ServiceResultError<int>("Not Added Successfully");
            }

        }

        public ServiceResult<int> DeleteFromCart(string orderID)
        {
            var result = _orderReository.DeleteOrder(orderID);
            if (result > 0)
            {
                return new SuccessfulServiceResult<int>(result);

            }
            else
            {
                return new ServiceResultError<int>("Not Deleted Successfully");
            }

        }

        public ServiceResult<List<Order>> GetOrders(string CartID)
        {
            var orderList = _orderReository.GetOrdersByCartID(CartID);
            return new ServiceResult<List<Order>>() { Result = orderList};
        }

        public ServiceResult<int> UpdateOrder(Order order)
        {
           var updatedOrder = new Order()
           {
               ID= order.ID,
               CartID= order.CartID,
               OrderPrice= order.OrderPrice,
               SocksNumber = order.SocksNumber,
               SocksID= order.SocksID,
           };
            var result = _orderReository.UpdateOrder(updatedOrder);
            if (result > 0)
            {
                return new SuccessfulServiceResult<int>(result);

            }
            else
            {
                return new ServiceResultError<int>("Not Updated Successfully");
            }

        }
    }
}
