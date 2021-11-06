using InfBot.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloApp
{
    public class ApplicationContextForUsers : DbContext
    {
        public DbSet<BotUser> BotUsers { get; set; }

        public ApplicationContextForUsers()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BotUsers;Trusted_Connection=True;");
        }
    }
}