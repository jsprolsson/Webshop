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
        public List<Models.Order> Orders = Models.Order.orders;

        // prop som f�r data fr�n OnPost
        [BindProperty]
        public Models.Order Order { get; set; }
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
            Orders.Add(Order);
            return RedirectToPage("/AddCustomer");
        }
    }
}
