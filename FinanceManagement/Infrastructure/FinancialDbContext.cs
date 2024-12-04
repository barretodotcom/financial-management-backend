
using FinanceManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.Infrastructure
{
    public class FinancialDbContext : DbContext
    {
        public DbSet<Expensive> Expensives { get; set; }   
        public DbSet<User> User { get; set; }   

        public FinancialDbContext(DbContextOptions<FinancialDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userTypeBuilder = modelBuilder.Entity<User>();

            userTypeBuilder
                .HasMany(l => l.Expensives)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId);

        }

    }
}