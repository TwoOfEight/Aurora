using api.Authentication.Models;
using api.Authentication.Models.DTOs;
using api.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        //test
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] AuthRequest request)
        {
            if (request == null ||
                string.IsNullOrEmpty(request.UserName) ||
                string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            var validCredentials = await _authService.VerifyUserCredentials(request.UserName, request.Password);
            if (!validCredentials) return Unauthorized("Invalid username or password");

            var user = await _userService.GetByUsername(request.UserName);
            var token = _authService.GenerateJwtToken(user);

            AuthResponse response = new()
            {
                User = user.castToDto(),
                AuthToken = token
            };

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
        {
            if (request == null)
                return BadRequest("Request body cannot be null");

            // Ensure all fields are populated
            if (string.IsNullOrEmpty(request.UserName) ||
                string.IsNullOrEmpty(request.Password) ||
                string.IsNullOrEmpty(request.Email) ||
                string.IsNullOrEmpty(request.Name))
            {
                return BadRequest("All fields (UserName, Password, Email, Name) are required.");
            }

            try
            {
                User user = await _userService.Create(request);
                AuthResponse response = new()
                {
                    User = user.castToDto(),
                    AuthToken = _authService.GenerateJwtToken(user)
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}