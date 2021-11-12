using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    [BindProperties]
    public class ProductsModel : PageModel
    {
        public List<Models.Product> Products = Data.ProductManager.Products;
        public string SearchMessage { get; set; }
        public string Category { get; set; }


        public void OnGet(string category, string searchMessage)
        {
           if (searchMessage != null) Search(searchMessage);

            Category = category;

            if (category == "electronics")
            {
                Products = Products.Where(product => product.category == "electronics").ToList();
            }
            else if (category == "jewelery")
            {
                Products = Products.Where(product => product.category == "jewelery").ToList();
            }
            else if (category == "men's clothing")
            {
                Products = Products.Where(product => product.category == "men's clothing").ToList();
            }
            else if (category == "women's clothing")
            {
                Products = Products.Where(product => product.category == "women's clothing").ToList();
            }
        }

        public void Search(string search)
        {
            search = search.ToLower();
            Products = Products.Where(product => product.category.ToLower().Contains(search) || product.title.ToLower().Contains(search) || product.description.ToLower().Contains(search)).Select(product => product).ToList();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Products", new { SearchMessage });
        }

    }
}
