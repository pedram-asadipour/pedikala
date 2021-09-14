using System.Linq;
using _01_PedikalaQuery.Contract.Footer;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Infrastructure.EFCore;

namespace _01_PedikalaQuery.Query
{
    public class FooterQuery : IFooterQuery
    {
        private readonly SiteContext _context;

        public FooterQuery(SiteContext context)
        {
            _context = context;
        }

        public FooterQueryModel GetFooter()
        {
            var description = _context.Footer
                .Select(x => x.Description)
                .AsNoTracking()
                .First();

            var links = _context.FooterLink
                .Where(x => !x.IsRemove)
                .Select(x => new FooterLinkQueryModel
                {
                    Name = x.Name,
                    Link = x.Link
                })
                .AsNoTracking()
                .ToList();

            return new FooterQueryModel()
            {
                Description = description,
                Links = links
            };
        }
    }
}