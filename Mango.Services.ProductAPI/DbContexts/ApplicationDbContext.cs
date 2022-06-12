using Mango.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration  = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Product> Products { get; set; }

    }
}
