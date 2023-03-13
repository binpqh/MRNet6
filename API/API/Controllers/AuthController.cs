using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Requests;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthLogin authInput)
        {
            var req = new AuthRequest()
            {
                Username = authInput.Username,
                Password = authInput.Password,
                Ipv4 = Request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
            };
            var res = await _authService.Login(req);
            return Ok(res);
        }
    }
}
