using System.Collections.Generic;
using _01_Framework.Application;

namespace SiteManagement.Application.Contract.ContactUs
{
    public interface IContactUsApplication
    {
        List<ContactUsViewModel> GetMessages();
        int GetMessagesCount();
        OperationResult Create(CreateContactUs command);
        OperationResult SetStatus(long id);
        EditContactUsInfo GetInfo();
        OperationResult EditInfo(EditContactUsInfo command);
    }
}