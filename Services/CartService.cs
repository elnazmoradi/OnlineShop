using Domain.Contracts;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderService _orderService;
        public CartService(ICartRepository cartRepository, IOrderService orderService)
        {
            _cartRepository = cartRepository;
            _orderService = orderService;   
        }

        public ServiceResult<int> MakeCartForAccount(string accountID)
        {
            var cart = new Cart()
            {
                AccountID = Guid.Parse(accountID),
                ID= Guid.NewGuid(),
                TotalPrice= 0,
            };
            var result = _cartRepository.AddCart(cart);
            if (result > 0)
            {
                return new SuccessfulServiceResult<int>(result);

            }
            else
            {
                return new ServiceResultError<int>("Not Added Successfully");
            }

        }

        public ServiceResult<Cart> ShowAccountCart(string AccountID)
        {
            var cart = _cartRepository.GetCart(AccountID);
            cart.TotalPrice = _orderService.GetOrders(cart.ID.ToString()).Result.Sum(S => S.OrderPrice);
            cart.Orders = _orderService.GetOrders(cart.ID.ToString()).Result;
            return new ServiceResult<Cart>() { Result = cart};

        }

    }
}
