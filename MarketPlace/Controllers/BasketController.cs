using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        // GET api/<BasketController>/5
        [HttpGet("/basket")]
        public Basket Get(Guid id)
        {
            return _basketService.GetBasket(id);
        }

        // POST api/<BasketController>
        [HttpPost("/basket/create")]
        public async Task<Guid> Post([FromBody] BasketDTO basket)
        {
            return await _basketService.CreateBasket(basket);
        }
    }
}
