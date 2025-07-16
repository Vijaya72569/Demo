using Microsoft.EntityFrameworkCore;

namespace DbOrdersService.Models
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
