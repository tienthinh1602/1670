namespace build_shopping_cart.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);
    }
}

