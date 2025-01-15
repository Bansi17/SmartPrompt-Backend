using ECommerce_Backend.Services.DTOs;

namespace ECommerce_Backend.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<string> Register (RegisterDto registerDto);

        Task<string> Login(LoginDto loginDto);
    }
}
