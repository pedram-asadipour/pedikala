using BannerManagement.Domain.SliderAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BannerManagement.Infrastructure.EFCore.Mapping
{
    public class SliderMapping : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.ToTable("Sliders");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TitleOne)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.TitleTwo)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1200)
                .IsRequired();

            builder.Property(x => x.Image)
                .HasMaxLength(500);

            builder.Property(x => x.ImageAlt)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.ImageTitle)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.Link)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}