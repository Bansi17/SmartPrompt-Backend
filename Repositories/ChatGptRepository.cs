using ECommerce_Backend.Data;
using ECommerce_Backend.Models;
using ECommerce_Backend.Repositories.Interfaces;

namespace ECommerce_Backend.Repositories
{
    public class ChatGptRepository : IChatGptRepository
    {
        private readonly AppDbContext _context;

        public ChatGptRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddChatGptHistoryAsync(ChatGptHistory chatGptHistory)
        {
            await _context.ChatGptHistories.AddAsync(chatGptHistory);
            await _context.SaveChangesAsync();
        }
    }
}
