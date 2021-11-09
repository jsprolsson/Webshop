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

        public void OnGet(int id)
        {
            AllProducts = AllProducts.Where(product => product.id == id).ToList();
            Data.CartManager.AddToCart(AllProducts[0]);

        }
    }
}
