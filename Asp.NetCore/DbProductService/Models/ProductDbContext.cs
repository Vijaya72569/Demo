using Microsoft.EntityFrameworkCore;

namespace DbProductService.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Products> Products { get; set; }
    }
}
