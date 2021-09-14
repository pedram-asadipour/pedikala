using _01_Framework.Domain;

namespace SiteManagement.Domain.FooterAgg
{
    public class Footer : EntityBase
    {
        public string Description { get; private set; }

        protected Footer()
        {
        }

        public Footer(string description)
        {
            Description = description;
        }

        public void Edit(string description)
        {
            Description = description;
        }
    }
}