using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages.Admin
{
    public class ChangeProductModel : PageModel
    {
        public List<Models.Product> Products = Data.ProductManager.Products;
        [BindProperty(SupportsGet = true)]
        public string Message { get; set; }

        [BindProperty]
        public Models.Product Product { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPostChange()
        {
            Data.CartManager.EmptyCart();

            if (ModelState.IsValid)
            {
                Data.ProductManager.ChangeProduct(Product);
                return RedirectToPage("/Admin/ChangeProduct");
            }
            else
            {
                Message = "Fill in all product info";
                return RedirectToPage("/Admin/ChangeProduct", new { Message });
            }
        }
    }
}
