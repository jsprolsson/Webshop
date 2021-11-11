using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class CartModel : PageModel
    {
        public List<Models.Product> AllProducts = Data.ProductManager.Products;

        public List<Models.OrderItem> Cart = Data.CartManager.Cart;

        public IEnumerable<IGrouping<string, Models.OrderItem>> CartGroups = Data.CartManager.GroupCartByProducts();

        [BindProperty]
        public Models.Customer Customer { get; set; }
        public double TotalSum { get; set; }
        public double VAT { get; set; }
        [BindProperty]
        public string GroupKey { get; set; }

        public void OnGet(int id)
        {
            if (id != 0)
            {
                //Tanken �r h�r att man kan skicka in Index 0 i metoden f�r att det alltid bara k�ps en grej �t g�ngen.
                var purchasedProduct = AllProducts.Where(product => product.id == id).ToList();
                Data.CartManager.AddToCart(purchasedProduct[0]);
            }

            TotalSum = Data.CartManager.GetCartSum();
            VAT = Math.Round(TotalSum * 0.25, 2);
            
        }

        public IActionResult OnPostAdd()
        {
            var addProduct = Cart.Where(product => product.Product.title == GroupKey).ToList();
            Data.CartManager.AddToCart(addProduct[0].Product);
            return RedirectToPage("/Cart");
        }

        public IActionResult OnPostRemove()
        {
            var removeProduct = Cart.Where(product => product.Product.title == GroupKey).ToList();
            Data.CartManager.RemoveFromCart(removeProduct[0].Product);
            return RedirectToPage("/Cart");
        }

        public IActionResult OnPostUser()
        {
            return RedirectToPage("/OrderComplete", new { Customer });
        }
    }
}
