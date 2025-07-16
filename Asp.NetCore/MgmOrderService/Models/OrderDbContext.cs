using Microsoft.EntityFrameworkCore;

namespace MgmOrderService.Models
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
