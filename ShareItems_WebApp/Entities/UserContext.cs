using Microsoft.EntityFrameworkCore;

namespace ShareItems_WebApp.Entities
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<UserCredential> UserCredentials { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserCredential>().ToTable("UserCredentials");
        }
    }
}
