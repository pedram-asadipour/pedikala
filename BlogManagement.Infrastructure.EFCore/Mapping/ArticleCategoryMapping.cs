using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.Image)
                .HasMaxLength(1000);

            builder.Property(x => x.ImageAlt)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.ImageAlt)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.Keyword)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.MetaDescription)
                .HasMaxLength(225)
                .IsRequired();
        }
    }
}