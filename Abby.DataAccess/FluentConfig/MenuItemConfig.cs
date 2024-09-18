using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Abby.Models;
namespace Abby.DataAccess.FluentConfig
{
    public class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            // Primary Keys
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();

            // Relations
            builder.HasOne(x => x.Category).WithMany(x => x.MenuItems)
                .HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.FoodType).WithMany(x => x.MenuItems)
                .HasForeignKey(x => x.FoodTypeId);
        }
    }
}
