using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Abby.Models;
namespace Abby.DataAccess.FluentConfig
{
    public class OrderDetailConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            // Primary Keys
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.MenuItemId).IsRequired();
            builder.Property(x => x.Count).IsRequired();
            builder.Property(x => x.MenuItemPrice).IsRequired();
            builder.Property(x => x.MenuItemName).IsRequired();

            // Relations
            builder.HasOne(x => x.OrderHeader).WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.MenuItem).WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.MenuItemId);
        }
    }
}
