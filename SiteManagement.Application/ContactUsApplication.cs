using System.Collections.Generic;
using System.Linq;
using _01_Framework.Application;
using SiteManagement.Application.Contract.ContactUs;
using SiteManagement.Domain.ContactUsAgg;

namespace SiteManagement.Application
{
    public class ContactUsApplication : IContactUsApplication
    {
        private readonly IContactUsRepository _contactUsRepository;
        private readonly IContactUsInfoRepository _contactUsInfoRepository;

        public ContactUsApplication(IContactUsRepository contactUsRepository, IContactUsInfoRepository contactUsInfoRepository)
        {
            _contactUsRepository = contactUsRepository;
            _contactUsInfoRepository = contactUsInfoRepository;
        }

        public List<ContactUsViewModel> GetMessages()
        {
            return _contactUsRepository.GetMessages();
        }

        public int GetMessagesCount()
        {
            return _contactUsRepository.GetMessagesCount();
        }

        public OperationResult Create(CreateContactUs command)
        {
            var operationResult = new OperationResult();

            var contactUs = new ContactUs(command.Name, command.Email, command.Message);

            _contactUsRepository.Create(contactUs);

            _contactUsRepository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult SetStatus(long id)
        {
            var operationResult = new OperationResult();

            var contactUs = _contactUsRepository.GetBy(id);

            contactUs.SetStatus();

            _contactUsRepository.SaveChange();

            return operationResult.Succeeded();
        }

        public EditContactUsInfo GetInfo()
        {
            return _contactUsInfoRepository.GetInfo();
        }

        public OperationResult EditInfo(EditContactUsInfo command)
        {
            var operationResult = new OperationResult();

            var contactUsInfo = _contactUsInfoRepository.GetAll().First();

            contactUsInfo.Edit(command.Description,command.Location);

            _contactUsInfoRepository.Edit(contactUsInfo);

            _contactUsRepository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}