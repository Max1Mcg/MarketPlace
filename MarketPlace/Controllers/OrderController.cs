using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService= orderService;
        }
        // GET: api/<OrderController>
        [HttpGet("order")]
        public OrderDTO Get(Guid id)
        {
            return _orderService.GetOrder(id);
        }

        // POST api/<OrderController>
        [HttpPost("/order/create")]
        public async Task<Guid> Post([FromBody] OrderDTO orderDTO)
        {
            return await _orderService.CreateOrder(orderDTO);
        }
    }
}
