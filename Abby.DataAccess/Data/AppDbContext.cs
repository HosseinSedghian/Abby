using Microsoft.EntityFrameworkCore;
using Abby.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Abby.DataAccess.FluentConfig;

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
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new FoodTypeConfig());
            builder.ApplyConfiguration(new MenuItemConfig());
            builder.ApplyConfiguration(new OrderDetailConfig());
            builder.ApplyConfiguration(new OrderHeaderConfig());
            builder.ApplyConfiguration(new ShoppingCartConfig());
        }
    }
}
