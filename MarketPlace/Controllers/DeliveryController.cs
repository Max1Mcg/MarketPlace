using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }
        [HttpGet]
        public IEnumerable<DeliveryDTO> Get()
        {
            return _deliveryService.GetDeliveries();
        }

        [HttpPost("create")]
        public void Post([FromBody] DeliveryDTO deliveryDTO)
        {
            _deliveryService.CreateDelivery(deliveryDTO);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateDelivery(int id, [FromBody] DeliveryDTO deliveryDTO)
        {
            await _deliveryService.UpdateDelivery(id, deliveryDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDelivery(int id)
        {
            await _deliveryService.DeleteDelivery(id);
            return Ok();
        }
    }
}
