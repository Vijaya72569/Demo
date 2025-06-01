using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace CoreEFCurd.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) 
        { }
        public DbSet<Product> Products { get; set; }


    }
}
