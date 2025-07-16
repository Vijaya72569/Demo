using Microsoft.EntityFrameworkCore;

namespace MSserviceUser.Models
{
    public class UserrsDbContext:DbContext
    {
        public UserrsDbContext(DbContextOptions<UserrsDbContext> options) : base(options) { }
        public DbSet<Userrs> Userrs { get; set; }
    }
}
