using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EFCore.Mapping
{
    public class ColleagueRoleMapping : IEntityTypeConfiguration<ColleagueRole>
    {
        public void Configure(EntityTypeBuilder<ColleagueRole> builder)
        {
            builder.ToTable("ColleagueRole");
            builder.HasKey(x => x.Id);
        }
    }
}