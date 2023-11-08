using BankSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Data
{
    public class BankDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=bank.db");
            optionsBuilder.UseSqlite("Data Source = D:\\DockerProject\\SistemaBancario\\SistemaBancario\\bank.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define model configurations, if needed.
        }
    }
}
