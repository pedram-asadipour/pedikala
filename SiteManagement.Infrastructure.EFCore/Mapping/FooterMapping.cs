using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManagement.Domain.FooterAgg;

namespace SiteManagement.Infrastructure.EFCore.Mapping
{
    public class FooterMapping : IEntityTypeConfiguration<Footer>
    {
        public void Configure(EntityTypeBuilder<Footer> builder)
        {
            builder.ToTable("Footer");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);
        }
    }
}