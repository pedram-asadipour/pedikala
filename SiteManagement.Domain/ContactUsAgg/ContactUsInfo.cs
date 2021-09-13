using _01_Framework.Domain;

namespace SiteManagement.Domain.ContactUsAgg
{
    public class ContactUsInfo : EntityBase
    {
        public string Description { get; private set; }
        public string Location { get; private set; }

        protected ContactUsInfo()
        {
        }

        public ContactUsInfo(string description, string location)
        {
            Description = description;
            Location = location;
        }

        public void Edit(string description, string location)
        {
            Description = description;
            Location = location;
        }
    }
}