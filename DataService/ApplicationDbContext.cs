using Microsoft.EntityFrameworkCore;
using ModelService;

namespace DataService
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}


/* NUGET PACKAGES TO INSTALL
 * Microsoft.AspNetCore.DataProtection.EntityFrameworkCore
 * Microsoft.AspNetCore.Identity.EntityFrameworkCore
 * Microsoft.EntityFrameworkCore.Design
 * Microsoft.EntityFrameworkCore.Tools
 */
