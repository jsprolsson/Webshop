using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class OrderCompleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Models.Customer Customer { get; set; }

        public IEnumerable<IGrouping<string, Models.OrderItem>> SummaryCart = Data.CartManager.GroupCartByProducts();

        public double TotalSum { get; set; }
        public double VAT { get; set; }
        public void OnGet()
        {
            TotalSum = Data.CartManager.GetCartSum();
            VAT = Math.Round(TotalSum * 0.25, 2);
        }
    }
}
