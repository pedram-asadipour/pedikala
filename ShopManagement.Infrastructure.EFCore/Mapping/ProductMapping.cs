using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.ProductCode)
               .HasMaxLength(15)
               .IsRequired();

            builder.Property(x => x.ShortDescription)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(5000);

            builder.Property(x => x.Image)
                .HasMaxLength(1000);

            builder.Property(x => x.ImageAlt)
                .HasMaxLength(225);

            builder.Property(x => x.ImageTitle)
                .HasMaxLength(500);

            builder.Property(x => x.Keyword)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.MetaDescription)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(x => x.ProductCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
