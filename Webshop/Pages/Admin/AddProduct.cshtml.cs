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
        // listan som ska visas p� view
        public List<Models.Product> Products = Data.ProductManager.Products;

        // prop som f�r data fr�n OnPost
        [BindProperty]
        public Models.Product Product { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Data.CartManager.EmptyCart();
            // Product kommer fr�n prop
            Data.ProductManager.Products.Add(Product);
            return RedirectToPage("/Admin/AddProduct");
        }
    }
}
