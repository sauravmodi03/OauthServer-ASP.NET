
using Microsoft.EntityFrameworkCore;
using ResourceServer.Entity;

namespace ResourceServer
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
            string connectionString = "User ID=postgres;Password=root;Host=localhost;Port=5432;Database=postgres;Pooling=true;Connection Lifetime=0;";
            optionsBuilder.UseNpgsql(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Todo> Todos { get; set; }
    }
}

