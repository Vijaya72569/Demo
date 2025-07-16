using Microsoft.EntityFrameworkCore;

namespace MSUser.Models
{
    public class UserDbContext :DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }

    }
}
