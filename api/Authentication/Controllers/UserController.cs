using api.Authentication.Models;
using api.Authentication.Models.DTOs;
using api.Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _userService.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [Authorize(Policy = "Manager")]
        [HttpGet("exists/{id}")]
        public async Task<ActionResult<bool>> Exists(int id)
        {
            var exists = await _userService.Exists(id);
            return Ok(exists);
        }

        [Authorize(Policy = "Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var entries = await _userService.GetAll();
            return Ok(entries);
        }

        [Authorize(Policy = "Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Authorize(Policy = "Admin")]
        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update(UserDTO user)
        {
            var updatedUser = await _userService.Update(user);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);
        }
    }
}