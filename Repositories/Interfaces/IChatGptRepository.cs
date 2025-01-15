using ECommerce_Backend.Models;

namespace ECommerce_Backend.Repositories.Interfaces
{
    public interface IChatGptRepository
    {
        Task AddChatGptHistoryAsync(ChatGptHistory chatGptHistory);

    }
}
