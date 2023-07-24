using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        IReceiptService _receiptService;
        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }
        /// <summary>
        /// Информирование и том, что оплата была произведена
        /// </summary>
        /// <param name="id">id квитации на оплату</param>
        /// <returns></returns>
        [HttpPatch("{id}/hasPayment")]
        public async Task<ActionResult> Payment(Guid id)
        {
            try
            {
                await _receiptService.Payment(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
