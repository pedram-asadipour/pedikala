using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Contract.Footer;
using SiteManagement.Domain.FooterAgg;

namespace SiteManagement.Infrastructure.EFCore.Repository
{
    public class FooterLinkRepository : GenericRepository<FooterLink,long> , IFooterLinkRepository
    {
        private readonly SiteContext _context;
        public FooterLinkRepository(SiteContext context) : base(context)
        {
            _context = context;
        }

        public List<FooterLinkViewModel> GetFooterLinks()
        {
            return _context.FooterLink
                .Select(x => new FooterLinkViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Link = x.Link,
                    IsRemove = x.IsRemove,
                    CreationDate = DateConvention.ToPersianDate(x.CreationDate)
                })
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToList();
        }

        public EditFooterLink GetFooterLink(long id)
        {
            return _context.FooterLink
                .Select(x => new EditFooterLink
                {
                    Id = x.Id,
                    Name = x.Name,
                    Link = x.Link
                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }
    }
}