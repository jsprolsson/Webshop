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
        public List<Models.OrderItem> Cart = Data.CartManager.Cart;

        public void OnGet()
        {

        }
    }
}
