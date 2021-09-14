using System.Collections.Generic;
using _01_Framework.Application;

namespace SiteManagement.Application.Contract.Footer
{
    public interface IFooterApplication
    {
        EditFooter GetFooter();
        OperationResult EditFooter(EditFooter command);

        List<FooterLinkViewModel> GetFooterLinks();
        EditFooterLink GetFooterLink(long id);
        OperationResult CreateLink(CreateFooterLink command);
        OperationResult EditLink(EditFooterLink command);
        OperationResult RemoveLink(long id);
        OperationResult RestoreLink(long id);
    }
}