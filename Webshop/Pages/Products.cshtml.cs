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
        public List<Models.GroupSale> GroupSale = Data.ProductManager.GroupSales;
        public string SearchMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }

        public void OnGet()
        {
        }

        public void OnPostSearch()
        {

            Products = Data.ProductManager.SearchForProduct(SearchMessage);
            GroupSale = Data.ProductManager.SearchForGroupProduct(SearchMessage);
        }

        public void OnPostCategory(string category)
        {
            if (category == "group")
            {
                Products = Data.ProductManager.GetGroupCategory(category);
            }
            else
            {
                Products = Data.ProductManager.GetCategory(category);
            }
        }

    }
}
