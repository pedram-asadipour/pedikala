using _01_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using SiteManagement.Application.Contract.ContactUs;

namespace ServiceHost.Pages
{
    public class ContactUsModel : PageModel
    {
        private readonly IContactUsApplication _application;

        public CreateContactUs Command { get; set; }
        public EditContactUsInfo Info { get; set; }
        [ViewData] public bool StatusMessage { get; set; }
        [ViewData] public string ResultMessage { get; set; }

        public ContactUsModel(IContactUsApplication application)
        {
            _application = application;
        }

        public void OnGet()
        {
            Info = _application.GetInfo();
        }

        public IActionResult OnPost(CreateContactUs command)
        {
            Info = _application.GetInfo();

            if (!ModelState.IsValid)
            {
                StatusMessage = false;
                ResultMessage = ValidationMessages.AllRequired;

                return Page();
            }

            var json = _application.Create(command);

            StatusMessage = json.IsSucceeded;
            ResultMessage = json.Message;

            return Page();
        }
    }
}
