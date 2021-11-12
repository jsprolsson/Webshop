using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Webshop.Pages
{
    public class CartModel : PageModel
    {
        public List<Models.Product> AllProducts = Data.ProductManager.Products;

        public List<Models.OrderItem> Cart = Data.CartManager.Cart;
        //public List<Models.OrderItem> Cart = JsonSerializer.Deserialize<Models.OrderItem[]>(Cookie).ToList();

        public IEnumerable<IGrouping<string, Models.OrderItem>> CartGroups = Data.CartManager.GroupCartByProducts();

        [BindProperty]
        public Models.Order Order { get; set; }
        public double TotalSum { get; set; }
        public double VAT { get; set; }
        [BindProperty]
        public string GroupKey { get; set; }
        //public static string Cookie { get; set; }

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
            
            // Läser in cookie
            Cart = JsonSerializer.Deserialize<Models.OrderItem[]>(Request.Cookies["cart"]).ToList();
            CartGroups = JsonSerializer.Deserialize<IGrouping<string, Models.OrderItem>>(Request.Cookies["cartGroups"]).ToList();

            // Skapar cookie
            string fullCart = JsonSerializer.Serialize(Cart);
            string fullCartGroups = JsonSerializer.Serialize(CartGroups);
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Append("cart", fullCart, options);
            Response.Cookies.Append("cartGroups", fullCartGroups, options);
            //var cart = Request.Cookies["cart"];
            //Cookie = Request.Cookies["cart"];
            //Data.CartManager.MakeCookie(cart);
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
            Models.Order.orders.Add(Order);
            return RedirectToPage("/Checkout");
        }
    }
}
