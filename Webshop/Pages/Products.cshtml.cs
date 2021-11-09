using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class ProductsModel : PageModel
    {
        public List<Models.Product> Products = Data.ProductManager.Products; 
        public void OnGet(string category)
        {
            string tempCategory = category;

            if (category == "electronics") {
                Products = Products.Where(product => product.category == tempCategory).ToList();
            } else if (category == "jewelery") {
                Products = Products.Where(product => product.category == tempCategory).ToList();
            } else if (category == "men's clothing"){
                Products = Products.Where(product => product.category == tempCategory).ToList();
            }
        }

        

    }
}
