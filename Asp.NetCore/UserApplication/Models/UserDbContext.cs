 using Microsoft.EntityFrameworkCore;
namespace UserApplication.Models
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
