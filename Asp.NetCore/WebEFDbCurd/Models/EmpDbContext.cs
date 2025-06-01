using Microsoft.EntityFrameworkCore;
namespace WebEFDbCurd.Models
{
    public class EmpDbContext:DbContext
    {
      public  EmpDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<EmpModel> Employee { get; set; }
        

        
        
    }
}
