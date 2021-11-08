using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop.Pages
{
    public class IndexModel : PageModel
    {
        public List<Models.Product> Products = Data.ProductManager.Products;

        public void OnGet()
        {
            Products = Products.Where(product => product.chosen).ToList();
        }
    }
}
