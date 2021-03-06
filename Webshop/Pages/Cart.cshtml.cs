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

        public List<Models.Product> Cart = Data.CartManager.Cart;

        public IEnumerable<IGrouping<string, Models.Product>> CartGroups = Data.CartManager.GroupCartByProducts();
        [BindProperty(SupportsGet = true)]
        public int ItemID { get; set; }

        [BindProperty]
        public Models.Order Order { get; set; }
        public double TotalSum { get; set; }
        public double VAT { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GroupKey { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserMessage { get; set; }

        public void OnGet()
        {
            //tar emot ItemID från Products-sidan. Om det inte är 0 så lägger den till i Cart-listan.
            //problem med det är att ItemID går att få åtkomst till och manipulera i URL:en.
            if (ItemID != 0) AddToCart();

            //metod för att skapa en cookie med cartens innehåll varje gång sidan laddas.
            //Detta funkar men vi har valt att kommentera bort då cookiefilen snabbt blir för stor för att spara och kraschar sidan vid för många items i kundkorgen.
            //CreateCookie(); 


            //beräknar summa och moms.
            TotalSum = Data.CartManager.GetCartSum();
            VAT = Math.Round(TotalSum * 0.25, 0);
        }

        public void CreateCookie()
        {
            // Skapar cart-cookie
            string fullCart = JsonSerializer.Serialize(Cart);
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Append("cart", fullCart, options);

            // Session cookie, fungerade inte med den nuvarande uppbyggnaden av hemsidan då vi bara har en "session"
            /*HttpContext.Session.SetString("Cart", fullCart);
            var sessionCookie = HttpContext.Session.GetString("Cart");
            Cart = JsonSerializer.Deserialize<Models.OrderItem[]>(HttpContext.Session.GetString("Cart")).ToList(); */
        }

        public void AddToCart()
        {
            //Tanken här är att man kan skicka in Index 0 i metoden för att det alltid bara köps en grej åt gången.
            var purchasedProduct = AllProducts.Where(product => product.id == ItemID).ToList();
            Data.CartManager.AddToCart(purchasedProduct[0]);
        }

        public IActionResult OnPostAdd()
        {
            //lägger till item beroende på vilken GroupKey den tillhör i CartGroups till Vanliga Cart-listan med plus-knappen.

            var addProduct = Cart.Where(product => product.title == GroupKey).ToList();
            Data.CartManager.AddToCart(addProduct[0]);
            return RedirectToPage("/Cart");
            
        }

        public IActionResult OnPostRemove()
        {
            //lägger till items i cart med minus-knappen.

            var removeProduct = Cart.Where(product => product.title == GroupKey).ToList();
            Data.CartManager.RemoveFromCart(removeProduct[0]);
            return RedirectToPage("/Cart");
        }

        public IActionResult OnPostUser()
        {
            //kollar om all orderinfo är korrekt ifylld. om inte returneras en sträng. annars skickas man till checkout-sidan.
            //orders.clear körs för att inte det ska bli dubbelt med order-info om man inte köper, sen kommer tillbaks och fyller i info igen.
            //hemsidan tillåter bara en kund i nuläget, tyvärr.

            if (ModelState.IsValid)
            {
                Models.Order.orders.Clear();
                Models.Order.orders.Add(Order);
                return RedirectToPage("/Checkout");
            }
            else
            {
                UserMessage = "Please fill in your information correctly.";
                return RedirectToPage("/Cart", new { UserMessage });
            }
            
        }
    }
}
