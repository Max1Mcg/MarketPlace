using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }
        // GET: api/<DeliveryController>
        [HttpGet("/deliveries")]
        public IEnumerable<Delivery> Get()
        {
            return _deliveryService.GetDeliveries();   
        }

        // POST api/<DeliveryController>
        [HttpPost("delivery/create")]
        public void Post([FromBody] DeliveryDTO deliveryDTO)
        {
            _deliveryService.CreateDelivery(deliveryDTO);
        }
    }
}
