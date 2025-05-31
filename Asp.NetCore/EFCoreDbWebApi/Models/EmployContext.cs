using Microsoft.EntityFrameworkCore;

namespace EFCoreDbWebApi.Models
{
    public class EmployContext:DbContext
    {
      EmployContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmpModel> Employe { get; set; }
    }
}
