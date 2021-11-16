using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class CheckoutModel : PageModel
    {
        public List<Models.Order> orders = Models.Order.orders;
        public IEnumerable<IGrouping<string, Models.Product>> CartGroups = Data.CartManager.GroupCartByProducts();
        public double Sum { get; set; }
        public double VAT { get; set; }
        public int Postage { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            foreach (var item in orders)
            {
                Postage = item.postage;
            }

            Sum = Data.CartManager.GetCartSum();
            VAT = Math.Round(Sum * 0.25, 2);
        }

        public void OnPostFinalize()
        {
            string message = Data.CartManager.EmptyCart();
            Message = message;
        }
    }
}
