using Microsoft.EntityFrameworkCore;

namespace WebAppCache.Models
{
    public class EmpContext:DbContext
    {
      public  EmpContext(DbContextOptions<EmpContext> options) : base(options)
        {
        }
        public DbSet<Emp> Employ { get; set; }
    }
}
