using MarketPlace.Models;
using MarketPlace.Models.DTOs;
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
        [HttpGet("/basket")]
        public BasketDTO Get(Guid id)
        {
            return _basketService.GetBasket(id);
        }
        [HttpPost("/basket/create")]
        public async Task<Guid> Post([FromBody] BasketDTO basket)
        {
            return await _basketService.CreateBasket(basket);
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateBasket(Guid id, [FromBody] BasketDTO basketDTO)
        {
            await _basketService.UpdateBasket(id, basketDTO);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            await _basketService.DeleteBasket(id);
            return Ok();
        }
    }
}
