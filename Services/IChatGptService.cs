using ECommerce_Backend.Services.DTOs;

namespace ECommerce_Backend.Services
{
    public interface IChatGptService
    {

        Task<ChatGptResponseDto> GetGptResponseAsync(ChatGptRequestDto requestDto);

    }
}
