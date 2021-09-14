using Microsoft.EntityFrameworkCore;
using SiteManagement.Domain.ContactUsAgg;
using SiteManagement.Domain.FooterAgg;
using SiteManagement.Infrastructure.EFCore.Mapping;

namespace SiteManagement.Infrastructure.EFCore
{
    public class SiteContext : DbContext
    {
        public SiteContext(DbContextOptions<SiteContext> options) : base(options)
        {
        }

        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<ContactUsInfo> ContactUsInfo { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<FooterLink> FooterLink { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ContactUsMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}