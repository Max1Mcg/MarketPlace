using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        //if way == /create, swagger generate some error(not unique path)
        [HttpPost("/create_")]
        public async Task<Guid> Create([FromBody] ItemDTO itemDTO)
        {
            return await _itemService.CreateItem(itemDTO);
        }
        [HttpGet("/Item")]
        public ActionResult<ItemDTO> Item(Guid id)
        {
            return Ok(_itemService.GetItem(id));
        }
    }
}
