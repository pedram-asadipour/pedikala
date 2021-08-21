using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fullname)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.Username)
                .HasMaxLength(225)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.Mobile)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.ProfileImage)
                .HasMaxLength(1000);
        }
    }
}