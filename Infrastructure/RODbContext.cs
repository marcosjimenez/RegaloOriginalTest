using Microsoft.EntityFrameworkCore;
using RegaloOriginalTest.Domain.Models;

namespace RegaloOriginalTest.Infrastructure
{
    public class RODbContext : DbContext
    {
        private const string ConnectionName = "RegaloOriginalDB";
        protected readonly IConfiguration Configuration;

        public RODbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString(ConnectionName));
        }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<ItemVenta> ItemsVenta { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
