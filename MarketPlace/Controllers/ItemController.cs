using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost("create")]
        public async Task<Guid> Create([FromBody] ItemDTO itemDTO)
        {
            return await _itemService.CreateItem(itemDTO);
        }
        [HttpGet("{id}")]
        public ActionResult<ItemDTO> Item(Guid id)
        {
            try
            {
                return Ok(_itemService.GetItem(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateItem(Guid id, [FromBody] ItemDTO itemDTO)
        {
            await _itemService.UpdateItem(id, itemDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            await _itemService.DeleteItem(id);
            return Ok();
        }
    }
}
