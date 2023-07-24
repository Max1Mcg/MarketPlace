using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Models.Requests;
using MarketPlace.Services;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILogger<BasketController> _logger;
        public BasketController(IBasketService basketService,
            ILogger<BasketController> logger)
        {
            _basketService = basketService;
            _logger = logger;
        }
        /// <summary>
        /// Получение корзины по id
        /// </summary>
        /// <param name="id">id корзины</param>
        /// <returns>дто корзины</returns>
        [HttpGet("{id}")]
        public BasketDTO Get(Guid id)
        {
            return _basketService.GetBasket(id);
        }
        /// <summary>
        /// Добавление корзины
        /// </summary>
        /// <param name="basket">дто для добавления корзины</param>
        /// <returns>guid добавленной корзины</returns>
        [HttpPost("create")]
        public async Task<Guid> Post([FromBody] BasketDTO basket)
        {
            return await _basketService.CreateBasket(basket);
        }
        /// <summary>
        /// Обновление элементов в корзине
        /// </summary>
        /// <param name="id">айди корзины</param>
        /// <param name="basketDTO">дто, которое показывает как корзина будет изменена</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateBasket(Guid id, [FromBody] BasketDTO basketDTO)
        {
            await _basketService.UpdateBasket(id, basketDTO);
            return Ok();
        }
        /// <summary>
        /// Удаление корзины
        /// </summary>
        /// <param name="id">id корзины</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasket(Guid id)
        {
            await _basketService.DeleteBasket(id);
            return Ok();
        }
        /// <summary>
        /// Удаление предмета из корзины
        /// </summary>
        /// <param name="itemId">id предмета</param>
        /// <param name="id">id корзины</param>
        /// <returns></returns>
        [HttpDelete("{id}/item")]
        public async Task<ActionResult> DeleteItemFromBasket([FromBody]List<Guid> itemsIds, Guid id)
        {
            try
            {
                await _basketService.DeleteItemsFromBasket(itemsIds, id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPatch("{id}/item")]
        public async Task<ActionResult> AddItemToBasket([FromBody]List<Guid> itemsIds, Guid id)
        {
            try
            {
                await _basketService.AddItemsToBasket(itemsIds, id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        /// <summary>
        /// Оформление корзины, формирующее заказ
        /// </summary>
        /// <param name="orderingBody">Параметры необходимые для формирования заказа</param>
        /// <param name="id">id корзины</param>
        /// <returns>id счёта на оплату</returns>
        [HttpPost("{id}/ordering")]
        public async Task<ActionResult<Guid>> BasketToOrder(OrderingBody orderingBody, Guid id)
        {
            try
            {
                return Ok(await _basketService.BasketToOrder(orderingBody.userId, orderingBody.deliveryId, id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
