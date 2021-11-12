using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class CheckoutModel : PageModel
    {
        public List<Models.Order> orders = Models.Order.orders;
        public IEnumerable<IGrouping<string, Models.OrderItem>> CartGroups = Data.CartManager.GroupCartByProducts();

        public void OnGet()
        {

        }
    }
}
