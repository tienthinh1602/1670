using build_shopping_cart.Data;
using build_shopping_cart.Helpers;
using build_shopping_cart.Models;
using Microsoft.AspNetCore.Mvc;

namespace build_shopping_cart.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly EFDataContext _context;

        public CheckoutController(EFDataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<Cart>("Cart");

            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(new Order());
        }

        [HttpPost]
        public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            var cart = HttpContext.Session.Get<Cart>("Cart");

            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var newOrder = new Order
            {
                FirstName = order.FirstName,
                LastName = order.LastName,
                Email = order.Email,
                Address = order.Address,
                City = order.City,
                State = order.State,
                ZipCode = order.ZipCode,
                OrderItems = cart.Items.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                }).ToList()
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Confirmation", new { orderId = newOrder.Id });
        }

        public IActionResult Confirmation(int orderId)
        {
            var order = _context.Orders.Find(orderId);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
