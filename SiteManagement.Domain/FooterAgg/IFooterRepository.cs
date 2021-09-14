using _01_Framework.Domain;
using SiteManagement.Application.Contract.Footer;

namespace SiteManagement.Domain.FooterAgg
{
    public interface IFooterRepository : IGenericRepository<Footer,long>
    {
        EditFooter GetFooter();
    }
}