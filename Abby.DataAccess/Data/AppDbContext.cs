using Microsoft.EntityFrameworkCore;
using Abby.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Abby.DataAccess.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
