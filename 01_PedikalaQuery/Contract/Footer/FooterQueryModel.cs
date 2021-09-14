using System.Collections.Generic;

namespace _01_PedikalaQuery.Contract.Footer
{
    public class FooterQueryModel
    {
        public string Description { get; set; }
        public List<FooterLinkQueryModel> Links { get; set; }
    }
}