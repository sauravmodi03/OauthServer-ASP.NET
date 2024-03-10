
using AuthenticationServer.Models;
using AuthServer.Entity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer
{

    public class DataContext : DbContext
    {

        public DataContext()
        { }

        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "User ID=postgres;Password=root;Host=localhost;Port=5432;Database=postgres;Pooling=true;";
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AccountVerification> AccountVerifications { get; set; }
        public DbSet<AccessToken> AccessTokens { get; set; }
    }
}

