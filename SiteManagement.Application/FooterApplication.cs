using System.Collections.Generic;
using _01_Framework.Application;
using SiteManagement.Application.Contract.Footer;
using SiteManagement.Domain.FooterAgg;

namespace SiteManagement.Application
{
    public class FooterApplication : IFooterApplication
    {
        private readonly IFooterRepository _footerRepository;
        private readonly IFooterLinkRepository _footerLinkRepository;

        public FooterApplication(IFooterRepository footerRepository, IFooterLinkRepository footerLinkRepository)
        {
            _footerRepository = footerRepository;
            _footerLinkRepository = footerLinkRepository;
        }

        public EditFooter GetFooter()
        {
            return _footerRepository.GetFooter();
        }

        public OperationResult EditFooter(EditFooter command)
        {
            var operationResult = new OperationResult();

            var footer = _footerRepository.GetBy(command.Id);

            footer.Edit(command.Description);

            _footerRepository.Edit(footer);

            _footerRepository.SaveChange();

            return operationResult.Succeeded();
        }

        public List<FooterLinkViewModel> GetFooterLinks()
        {
            return _footerLinkRepository.GetFooterLinks();
        }

        public EditFooterLink GetFooterLink(long id)
        {
            return _footerLinkRepository.GetFooterLink(id);
        }

        public OperationResult CreateLink(CreateFooterLink command)
        {
            var operationResult = new OperationResult();

            if (_footerLinkRepository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.Exists);

            var footerLink = new FooterLink(command.Name, command.Link);

            _footerLinkRepository.Create(footerLink);

            _footerLinkRepository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult EditLink(EditFooterLink command)
        {
            var operationResult = new OperationResult();

            var footerLink = _footerLinkRepository.GetBy(command.Id);

            if (footerLink == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            if (_footerLinkRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Exists);

            footerLink.Edit(command.Name, command.Link);

            _footerLinkRepository.Edit(footerLink);

            _footerLinkRepository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult RemoveLink(long id)
        {
            var operationResult = new OperationResult();

            var footerLink = _footerLinkRepository.GetBy(id);

            if (footerLink == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            footerLink.Remove();

            _footerLinkRepository.SaveChange();

            return operationResult.Succeeded();
        }

        public OperationResult RestoreLink(long id)
        {
            var operationResult = new OperationResult();

            var footerLink = _footerLinkRepository.GetBy(id);

            if (footerLink == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            footerLink.Restore();

            _footerLinkRepository.SaveChange();

            return operationResult.Succeeded();
        }
    }
}