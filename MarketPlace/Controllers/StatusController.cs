using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        // GET: api/<StatusController>
        [HttpGet("/statuses")]
        public IEnumerable<StatusDTO> Get()
        {
            return _statusService.GetStatuses();
        }

        // POST api/<StatusController>
        [HttpPost("/status/create")]
        public async Task<int> Post([FromBody]StatusDTO statusDTO)
        {
            return await _statusService.CreateStatus(statusDTO);
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateStatus(int id, [FromBody] StatusDTO statusDTO)
        {
            await _statusService.UpdateStatus(id, statusDTO);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteStatus(int id)
        {
            await _statusService.DeleteStatus(id);
            return Ok();
        }
    }
}
