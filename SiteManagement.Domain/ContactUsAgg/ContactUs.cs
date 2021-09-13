using _01_Framework.Domain;

namespace SiteManagement.Domain.ContactUsAgg
{
    public class ContactUs : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public bool Status { get; private set; }

        protected ContactUs()
        {
        }

        public ContactUs(string name, string email, string message)
        {
            Name = name;
            Email = email;
            Message = message;
            Status = false;
        }

        public void SetStatus()
        {
            Status = true;
        }
    }
}