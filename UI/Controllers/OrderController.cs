using Domain.Entities;
using Domain.Entities.DtoModels;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController( IOrderService orderService)
        {
            _orderService= orderService;
        }
        [HttpPost]
        [ActionName("add-order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddOrder([FromBody]OrderDto order) 
        {
            var result = _orderService.AddToCart(order);
            if (result.IsSuccessfull)
            {
                return Ok();
            }
            return BadRequest(result.ErrorMessage);
        }


        [HttpGet]
        [ActionName("delete-order")]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteOrder(string orederID)
        {
            var result = _orderService.DeleteFromCart(orederID);
            if (result.IsSuccessfull)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }

        }

        [HttpPost]
        [ActionName("update-order")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateOrder([FromBody]Order orederID)
        {
            var result = _orderService.UpdateOrder(orederID);
            if (result.IsSuccessfull)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }

        }
    }
}
