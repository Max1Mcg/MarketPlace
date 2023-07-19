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
        private readonly IBasketService _basketService;
        private readonly ILogger<BasketController> _logger;
        public BasketController(IBasketService basketService,
            ILogger<BasketController> logger)
        {
            _basketService = basketService;
            _logger = logger;
        }
        // GET api/<BasketController>/5
        [HttpGet("/basket")]
        public BasketDTO Get(Guid id)
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
