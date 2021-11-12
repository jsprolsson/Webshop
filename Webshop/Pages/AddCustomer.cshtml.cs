using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class AddCustomerModel : PageModel
    {
        // listan som ska visas på view
        public List<Models.Order> Orders = Models.Order.orders;

        // prop som får data från OnPost
        [BindProperty]
        public Models.Order Order { get; set; }
        public void OnGet()
        {
            
            var cookieValue1 = Request.Cookies["name"];
            var cookieValue2 = Request.Cookies["email"];
            var cookieValue3 = Request.Cookies["address"];

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Append("name", Order.name, options);
            Response.Cookies.Append("email", Order.email, options);
            Response.Cookies.Append("address", Order.address, options);


            // Customer kommer från prop
            Orders.Add(Order);
            return RedirectToPage("/AddCustomer");
        }
    }
}
