using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class AddCustomerModel : PageModel
    {
        // listan som ska visas p� view
        public List<Models.Customer> Customers = Models.Customer.customers;

        // prop som f�r data fr�n OnPost
        [BindProperty]
        public Models.Customer Customer { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            
            // Customer kommer fr�n prop
            Customers.Add(Customer);
            return RedirectToPage("/AddCustomer");
        }
    }
}
