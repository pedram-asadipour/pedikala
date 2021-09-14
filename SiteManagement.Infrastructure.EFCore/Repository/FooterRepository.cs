using System.Linq;
using _01_Framework.Domain;
using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Contract.Footer;
using SiteManagement.Domain.FooterAgg;

namespace SiteManagement.Infrastructure.EFCore.Repository
{
    public class FooterRepository : GenericRepository<Footer,long> ,IFooterRepository
    {
        private readonly SiteContext _context;
        public FooterRepository(SiteContext context) : base(context)
        {
            _context = context;
        }

        public EditFooter GetFooter()
        {
            return _context.Footer
                .Select(x => new EditFooter
                {
                    Id = x.Id,
                    Description = x.Description
                })
                .AsNoTracking()
                .First();
        }
    }
}