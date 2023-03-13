using build_shopping_cart.Data;
using build_shopping_cart.Helpers;
using build_shopping_cart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace build_shopping_cart.Controllers
{
    public class CartController : Controller
    {
        private readonly EFDataContext _context;

        public CartController(EFDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(item => item.ProductId == id);

            if (cartItem == null)
            {
                cart.Items.Add(new CartItem
                {
                    ProductId = id,
                    Quantity = 1,
                    Price = product.Price
                });
            }
            else
            {
                cartItem.Quantity++;
            }

            SaveCart(cart);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = GetCart();
            var cartItem = cart.Items.FirstOrDefault(item => item.ProductId == id);

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    cart.Items.Remove(cartItem);
                }

                SaveCart(cart);
            }

            return RedirectToAction(nameof(Index));
        }

        private Cart GetCart()
        {
            var cart = HttpContext.Session.Get<Cart>("Cart");

            if (cart == null)
            {
                cart = new Cart();
                SaveCart(cart);
            }

            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.Set("Cart", cart);
        }
    }
}
