﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

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
        }
    }
}