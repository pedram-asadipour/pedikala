using System.Collections.Generic;
using _01_Framework.Domain;
using SiteManagement.Application.Contract.Footer;

namespace SiteManagement.Domain.FooterAgg
{
    public interface IFooterLinkRepository : IGenericRepository<FooterLink,long>
    {
        List<FooterLinkViewModel> GetFooterLinks();
        EditFooterLink GetFooterLink(long id);
    }
}