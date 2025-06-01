using Microsoft.EntityFrameworkCore;
namespace EFCoreDbWebApi.Models
{
    public class EmpContext:DbContext
    {
        public EmpContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<EmpModel> Employe { get; set; }
    }
}
