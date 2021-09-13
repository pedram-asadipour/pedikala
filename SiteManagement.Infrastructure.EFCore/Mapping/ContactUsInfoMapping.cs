using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManagement.Domain.ContactUsAgg;

namespace SiteManagement.Infrastructure.EFCore.Mapping
{
    public class ContactUsInfoMapping : IEntityTypeConfiguration<ContactUsInfo>
    {
        public void Configure(EntityTypeBuilder<ContactUsInfo> builder)
        {
            builder.ToTable("ContactUsInfo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.Location)
                .HasMaxLength(1000);
        }
    }
}