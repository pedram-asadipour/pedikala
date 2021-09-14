using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManagement.Domain.FooterAgg;

namespace SiteManagement.Infrastructure.EFCore.Mapping
{
    public class FooterLinkMapping : IEntityTypeConfiguration<FooterLink>
    {
        public void Configure(EntityTypeBuilder<FooterLink> builder)
        {
            builder.ToTable("FooterLink");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Link)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}