using Microsoft.EntityFrameworkCore;

namespace Academy_2023.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
