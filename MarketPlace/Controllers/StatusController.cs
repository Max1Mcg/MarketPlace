﻿using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public IEnumerable<StatusDTO> Get()
        {
            return _statusService.GetStatuses();
        }

        [HttpPost("create")]
        public async Task<int> Post([FromBody]StatusDTO statusDTO)
        {
            return await _statusService.CreateStatus(statusDTO);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateStatus(int id, [FromBody] StatusDTO statusDTO)
        {
            await _statusService.UpdateStatus(id, statusDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStatus(int id)
        {
            await _statusService.DeleteStatus(id);
            return Ok();
        }
    }
}
