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
        public List<Models.Customer> Customers = Models.Customer.customers;

        // prop som får data från OnPost
        [BindProperty]
        public Models.Customer Customer { get; set; }
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
            Response.Cookies.Append("name", Customer.name, options);
            Response.Cookies.Append("email", Customer.email, options);
            Response.Cookies.Append("address", Customer.address, options);


            // Customer kommer från prop
            Customers.Add(Customer);
            return RedirectToPage("/AddCustomer");
        }
    }
}
