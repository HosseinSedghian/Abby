using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Abby.Models;
namespace Abby.DataAccess.FluentConfig
{
    public class ShoppingCartConfig : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            // Primary Keys
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.MenuItemId).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.ApplicationUserId).IsRequired();

            // Relations
            builder.HasOne(x => x.MenuItem).WithMany(x => x.ShoppingCarts)
                .HasForeignKey(x => x.MenuItemId);
            builder.HasOne(x => x.ApplicationUser).WithMany(x => x.ShoppingCarts)
                .HasForeignKey(x => x.ApplicationUserId);
        }
    }
}
