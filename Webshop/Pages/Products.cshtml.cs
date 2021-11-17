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
        public List<Models.GroupBuy> GroupSale = Data.ProductManager.GroupBuyItems;
        public string SearchMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Category { get; set; }


        public void OnGet()
        {
            //Displays category from navbar.
            if (Category != null)
            {
                Products = Data.ProductManager.Categories(Category);
                GroupSale = Data.ProductManager.GroupCategories(Category);
            }

        }


        public void OnPostSearch()
        {

            Products = Data.ProductManager.SearchForProduct(SearchMessage);
            GroupSale = Data.ProductManager.SearchForGroupProduct(SearchMessage);
        }

    }
}
