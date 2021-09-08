using System.Collections.Generic;
using _01_Framework.Application;
using _01_PedikalaQuery.Contract.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages.Account
{
    [Authorize]
    public class OrderModel : PageModel
    {
        private readonly IAuthHelper _authHelper;
        private readonly IOrderQuery _orderQuery;

        public AuthViewModel Account { get; set; }
        public List<OrderQueryModel> Orders { get; set; }

        public OrderModel( IOrderQuery orderQuery, IAuthHelper authHelper)
        {
            _orderQuery = orderQuery;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
            Account = _authHelper.GetCurrentAccount();
            Orders = _orderQuery.GetOrderBy(Account.AccountId);
        }
    }
}
