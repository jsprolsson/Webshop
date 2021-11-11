using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class AddProductModel : PageModel
    {
        public List<Models.Product> products = Data.ProductManager.Products;

        public void OnGet()
        {
            
        }


    }
}
