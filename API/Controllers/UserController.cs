using Application.Dtos;
using Application.Model;
using Application.Service.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))] 
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users);  
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel createUser)
        {
            await _userService.CreateUserAsync(createUser);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

    };

        
    
}