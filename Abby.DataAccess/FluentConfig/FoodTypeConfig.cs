using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Abby.Models;
namespace Abby.DataAccess.FluentConfig
{
    public class FoodTypeConfig : IEntityTypeConfiguration<FoodType>
    {
        public void Configure(EntityTypeBuilder<FoodType> builder)
        {
            // Primary keys
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
