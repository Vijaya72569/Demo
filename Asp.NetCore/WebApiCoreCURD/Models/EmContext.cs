using Microsoft.EntityFrameworkCore;
namespace WebApiCoreCURD.Models
{
    public class EmContext:DbContext
    {
        public EmContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Emp> Employ { get; set; }
    }
}
