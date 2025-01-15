using ECommerce_Backend.Models;
using ECommerce_Backend.Repositories.Interfaces;
using ECommerce_Backend.Services.DTOs;
using ECommerce_Backend.Shared;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ECommerce_Backend.Services
{
    public class ChatGptService : IChatGptService
    {
        private readonly IChatGptRepository _chatGptRepository;
        private readonly OpenAIConfig _openAIConfig;

        public ChatGptService(IChatGptRepository chatGptRepository, IOptions<OpenAIConfig> openAIConfig)
        {
            _chatGptRepository = chatGptRepository;
            _openAIConfig = openAIConfig.Value;
        }

        public async Task<ChatGptResponseDto> GetGptResponseAsync(ChatGptRequestDto requestDto)
        {
            var client = new HttpClient();
            var request = new
            {
                model = "gpt-3.5-turbo",
                prompt = requestDto.Message,
                max_tokens = 500
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _openAIConfig.ApiKey);

            var response = await client.PostAsync("https://api.openai.com/v1/completions", content);

            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"OpenAI API call failed with status code {response.StatusCode}. Response: {responseString}");
            }

            var result = JsonConvert.DeserializeObject<dynamic>(responseString);

            if (result?.choices != null && result.choices.Count > 0)
            {
                var gptResponse = result.choices[0].text.ToString();

                var chatHistory = new ChatGptHistory
                {
                    UserMessage = requestDto.Message,
                    GptResponse = gptResponse,
                    Timestamp = DateTime.UtcNow
                };

                await _chatGptRepository.AddChatGptHistoryAsync(chatHistory);

                return new ChatGptResponseDto { Response = gptResponse };
            }
            else
            {
                throw new Exception("OpenAI API response is not valid. 'choices' is null or empty.");
            }
        }

    }
}
