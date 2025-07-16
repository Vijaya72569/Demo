using Microsoft.EntityFrameworkCore;

namespace WebAPIEFCurd.Models
{
    public class EmpDbContext :DbContext
    {
      public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) { }
        public DbSet<Emp> Emp { get; set; }
    }
}
