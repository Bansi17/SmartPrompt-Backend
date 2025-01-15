using ECommerce_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Backend.Data
{
    public class AppDbContext :  DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<ChatGptHistory> ChatGptHistories { get; set; }
    }
}
