using ECommerce_Backend.Repositories.Interfaces;
using ECommerce_Backend.Services.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository) 
        {
           _authRepository = authRepository;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _authRepository.Register(registerDto);
            if(result == "Registeration successfull")
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authRepository.Login(loginDto);
            if (result == "Invalid Credentials")
                return Unauthorized(result);
            return Ok(new { Token = result });
        }

    }
}
