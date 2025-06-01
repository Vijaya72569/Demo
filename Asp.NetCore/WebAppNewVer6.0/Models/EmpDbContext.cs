using Microsoft.EntityFrameworkCore;

namespace WebAppNewVer6._0.Models
{
    public class EmpDbContext:DbContext
    {
        public EmpDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<EmpModel> Employee { get; set; }


    }
}
