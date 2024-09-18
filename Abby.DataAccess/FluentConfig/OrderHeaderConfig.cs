using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Abby.Models;
namespace Abby.DataAccess.FluentConfig
{
    internal class OrderHeaderConfig : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            // Primary Keys
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.ApplicationUserId).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.OrderTotalPrice).IsRequired();
            builder.Property(x => x.PickupTime).IsRequired();
            builder.Property(x => x.PickupDate).IsRequired();
            builder.Ignore(x => x.PickupDate);
            builder.Property(x => x.Status).IsRequired();

            // Relations
            builder.HasOne(x => x.ApplicationUser).WithMany(x => x.OrderHeaders)
                .HasForeignKey(x => x.ApplicationUserId);
        }
    }
}
