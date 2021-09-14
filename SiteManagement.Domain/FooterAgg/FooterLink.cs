using _01_Framework.Domain;

namespace SiteManagement.Domain.FooterAgg
{
    public class FooterLink : EntityBase
    {
        public string Name { get; private set; }
        public string Link { get; private set; }
        public bool IsRemove { get; private set; }

        protected FooterLink()
        {
        }

        public FooterLink(string name, string link)
        {
            Name = name;
            Link = link;
            IsRemove = false;
        }

        public void Edit(string name, string link)
        {
            Name = name;
            Link = link;
        }

        public void Remove()
        {
            IsRemove = true;
        }

        public void Restore()
        {
            IsRemove = false;
        }
    }
}