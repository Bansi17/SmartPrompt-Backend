namespace ECommerce_Backend.Models
{
    public class ChatGptHistory
    {
        public int Id { get; set; }
        public string? UserMessage { get; set; }
        public string? GptResponse { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
