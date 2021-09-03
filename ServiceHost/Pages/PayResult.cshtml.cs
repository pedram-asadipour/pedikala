using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    [Authorize]
    public class PayResultModel : PageModel
    {
        
        public bool Status { get; set; }
        public string IssueTrackingNo { get; set; }

        public void OnGet([FromQuery] bool status, [FromQuery] string issueTrackingNo)
        {
            Status = status;
            IssueTrackingNo = issueTrackingNo;
        }
    }
}
