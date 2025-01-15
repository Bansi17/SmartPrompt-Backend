using ECommerce_Backend.Services.DTOs;
using ECommerce_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGptController : ControllerBase
    {
        private readonly IChatGptService _chatGptService;

        public ChatGptController(IChatGptService chatGptService)
        {
            _chatGptService = chatGptService;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> AskChatGpt([FromBody] ChatGptRequestDto requestDto)
        {
            var response = await _chatGptService.GetGptResponseAsync(requestDto);
            return Ok(response);
        }
    }
}
