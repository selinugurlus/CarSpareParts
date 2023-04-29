using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication3.Models
{
    public class TableContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public TableContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("MyWebApiConnection"));
        }


       // public DbSet<Car> Cars { get; set; }
        
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
