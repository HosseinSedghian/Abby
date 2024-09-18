using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Abby.Models;
namespace Abby.DataAccess.FluentConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Primary Keys
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
