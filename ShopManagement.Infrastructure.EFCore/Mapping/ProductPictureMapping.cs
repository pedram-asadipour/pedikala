using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Image)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.ImageAlt)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.ImageTitle)
                .HasMaxLength(225)
                .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductPictures)
                .HasForeignKey(x => x.ProductId);
        }
    }
}