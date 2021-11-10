using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages.Admin
{
    public class AddProductModel : PageModel
    {
        // listan som ska visas på view
        public List<Models.Product> Products = Data.ProductManager.Products;

        // prop som får data från OnPost
        [BindProperty]
        public Models.Product Product { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            // Customer kommer från prop
            Products.Add(Product);
            return RedirectToPage("/Admin/AddProduct");
        }
    }
}
