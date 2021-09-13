using System.Collections.Generic;
using System.Linq;
using _01_Framework.Infrastructure;
using _01_Framework.Tools;
using Microsoft.EntityFrameworkCore;
using SiteManagement.Application.Contract.ContactUs;
using SiteManagement.Domain.ContactUsAgg;

namespace SiteManagement.Infrastructure.EFCore.Repository
{
    public class ContactUsRepository : GenericRepository<ContactUs,long> , IContactUsRepository
    {
        private readonly SiteContext _context;

        public ContactUsRepository(SiteContext context) : base(context)
        {
            _context = context;
        }

        public List<ContactUsViewModel> GetMessages()
        {
            return _context.ContactUs
                .Select(x => new ContactUsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    Status = x.Status,
                    CrationDate = x.CreationDate.ToPersianDate()
                })
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .ToList(); 
        }

        public int GetMessagesCount()
        {
            return _context.ContactUs
                .Where(x => !x.Status)
                .AsNoTracking()
                .Count();
        }
    }
}