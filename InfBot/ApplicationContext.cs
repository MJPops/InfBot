using InfBot.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Subject;Trusted_Connection=True;");
        }
    }
}
