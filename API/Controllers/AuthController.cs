using Application.Service.Interface;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private IAuthenticateService _authenticateService;
        public AuthController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticatedRequest request)
        { 
            return Ok( await _authenticateService.Authenticateḍ(request));
        }
    }
}
