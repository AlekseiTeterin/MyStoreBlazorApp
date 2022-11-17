using Microsoft.EntityFrameworkCore;
using MyStore.Models;

namespace MyStore.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        public DbSet<BasketElement> Basket => Set<BasketElement>();

        public DbSet<Account> Accounts => Set<Account>();
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasIndex(b => b.Email)
                .IsUnique();

        }
    }
}
