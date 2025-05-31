using Microsoft.EntityFrameworkCore;
namespace EFCURDCORE8.Models
{
    public class EmpDbContext:DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options):base(options) { }
        public DbSet<EmpModel> Employee { get; set; }
    }
}
