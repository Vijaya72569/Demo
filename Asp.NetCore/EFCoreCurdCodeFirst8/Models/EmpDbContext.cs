using Microsoft.EntityFrameworkCore;

namespace EFCoreCurdCodeFirst8.Models
{
    public class EmpDbContext:DbContext
    {
     public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) { }
        public DbSet<EmpModel> Emps { get; set; }
    }
}
