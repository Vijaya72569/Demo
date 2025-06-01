using Microsoft.EntityFrameworkCore;
using EFCoreCurdSP8.Models;
namespace EFCoreCurdSP8.Models
{
    public class EmpDbContext:DbContext
    {

     public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

    }
}
