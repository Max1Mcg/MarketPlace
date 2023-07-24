using Microsoft.AspNetCore.Mvc;
using MarketPlace.Models.DTOs;
using MarketPlace.Services.Interfaces;
using MarketPlace.Services;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody]UserDTO userDTO)
        {
            try
            {
                return Ok(await _userService.Registration(userDTO));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public ActionResult<UserDTO> User(Guid id)
        {
            try
            {
                return Ok(_userService.GetUser(id));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UserDTO orderDTO)
        {
            await _userService.UpdateUser(id, orderDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}
