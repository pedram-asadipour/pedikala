using CommandManagement.Domain.ProductCommandAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CommandManagement.Infrastructure.EFCore.Mapping
{
    public class ProductCommandMapping : IEntityTypeConfiguration<ProductCommand>
    {
        public void Configure(EntityTypeBuilder<ProductCommand> builder)
        {
            builder.ToTable("ProductCommands");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Message)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}