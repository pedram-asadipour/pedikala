using System;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Image)
                .HasMaxLength(1000);

            builder.Property(x => x.ImageAlt)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.ImageTitle)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.ShortDescription)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.Keyword)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.MetaDescription)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.CanonicalAddress)
                .HasMaxLength(1000);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}