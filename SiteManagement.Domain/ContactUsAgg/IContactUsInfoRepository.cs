using _01_Framework.Domain;
using SiteManagement.Application.Contract.ContactUs;

namespace SiteManagement.Domain.ContactUsAgg
{
    public interface IContactUsInfoRepository : IGenericRepository<ContactUsInfo, long>
    {
        EditContactUsInfo GetInfo();
    }
}