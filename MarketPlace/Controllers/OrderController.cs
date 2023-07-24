﻿using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("order")]
        public OrderDTO Get(Guid id)
        {
            return _orderService.GetOrder(id);
        }

        [HttpPost("/order/create")]
        public async Task<Guid> Post([FromBody] OrderDTO orderDTO)
        {
            return await _orderService.CreateOrder(orderDTO);
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateOrder(Guid id, [FromBody] OrderDTO orderDTO)
        {
            await _orderService.UpdateOrder(id, orderDTO);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteOrder(id);
            return Ok();
        }
        /// <summary>
        /// Отмена оформленного заказа
        /// </summary>
        /// <param name="id">id заказа</param>
        /// <returns>Строка, имулирующая необходимость вернуть средства пользователю или её отсутствие</returns>
        [HttpPatch("order/cancel")]
        public async Task<ActionResult<string>> CancelOrder(Guid id)
        {
            return Ok(await _orderService.CancelOrder(id));
        }
    }
}
