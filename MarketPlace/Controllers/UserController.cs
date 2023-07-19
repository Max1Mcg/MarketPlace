using Microsoft.AspNetCore.Mvc;
using MarketPlace.Models.DTOs;
using MarketPlace.Services.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<ValuesController>
        [HttpPost("/registration")]
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
        [HttpGet("/user")]
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
    }
}
