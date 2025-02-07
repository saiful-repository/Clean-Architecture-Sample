using Asp.Versioning;
using CleanArchitectureSample.Application.DTOs;
using CleanArchitectureSample.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSample.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        public AuthController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken(LoginDto loginDto)
        {
            try
            {
                var user = await _userService.GetUserAsync(loginDto);
                var token = _jwtService.GenerateToken(user.UserId, new List<string> { user.Role });
                return Ok(new { Token = token });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
