namespace SiteManagement.Application.Contract.Footer
{
    public class FooterLinkViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool IsRemove { get; set; }
        public string CreationDate { get; set; }
    }
}