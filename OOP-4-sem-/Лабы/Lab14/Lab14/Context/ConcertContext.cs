using Lab14.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab14.Context
{
    public partial class ConcertContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<UserConcert> UserConcerts { get; set; }

        public ConcertContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-ADTTMHK8\\SQLEXPRESS;Database=Concert;Trusted_Connection=True;");
        }
    }
}
