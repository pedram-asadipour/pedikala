using System.Linq;
using _01_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Contract.ContactUs;
using SiteManagement.Domain.ContactUsAgg;

namespace SiteManagement.Infrastructure.EFCore.Repository
{
    public class ContactUsInfoRepository : GenericRepository<ContactUsInfo, long> ,IContactUsInfoRepository
    {
        private readonly SiteContext _context;

        public ContactUsInfoRepository(SiteContext context) : base(context)
        {
            _context = context;
        }

        public EditContactUsInfo GetInfo()
        {
            return _context.ContactUsInfo
                .Select(x => new EditContactUsInfo
                {
                    Id = x.Id,
                    Description = x.Description,
                    Location = x.Location
                })
                .AsNoTracking()
                .First();
        }
    }
}