using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTO.Auth;
using TaskFlow.Application.Interfaces.Auth;

namespace TaskFlow.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {

            var result = await _authService.RegisterAsync(request);
            if (!result.Success)
                return BadRequest(new { error = result.Error });
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var result = await _authService.LoginAsync(loginRequest);
            if (!result.Success)
                return Unauthorized(new { error = result.Error });
            return Ok(result.Value);
        }
    }
}
