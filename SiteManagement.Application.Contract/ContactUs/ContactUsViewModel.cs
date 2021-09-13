namespace SiteManagement.Application.Contract.ContactUs
{
    public class ContactUsViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public string CrationDate { get; set; }
    }
}