using System.Collections.Generic;
using _01_Framework.Domain;
using SiteManagement.Application.Contract.ContactUs;

namespace SiteManagement.Domain.ContactUsAgg
{
    public interface IContactUsRepository : IGenericRepository<ContactUs,long>
    {
        List<ContactUsViewModel> GetMessages();
        int GetMessagesCount();
    }
}