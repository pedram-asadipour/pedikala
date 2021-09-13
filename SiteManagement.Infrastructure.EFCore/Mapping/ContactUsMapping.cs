using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManagement.Domain.ContactUsAgg;

namespace SiteManagement.Infrastructure.EFCore.Mapping
{
    public class ContactUsMapping : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.ToTable("ContactUs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(225);

            builder.Property(x => x.Email)
                .HasMaxLength(225);

            builder.Property(x => x.Message)
                .HasMaxLength(225);
        }
    }
}