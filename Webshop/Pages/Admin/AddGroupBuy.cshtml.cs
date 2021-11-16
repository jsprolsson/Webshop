using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages.Admin
{
    public class AddGroupBuyModel : PageModel
    {
        public List<Models.Product> Products = Data.ProductManager.Products;
        public List<Models.GroupBuy> GroupBuyItems = Data.ProductManager.GroupBuyItems;

        [BindProperty]
        public int ProductID { get; set; }
        [BindProperty]
        public int GroupSize { get; set; }

        public void OnGet()
        {
        }

        public void OnPostToGroup()
        {
            Data.ProductManager.ProductToGroup(ProductID, GroupSize);
        }
    }
}
