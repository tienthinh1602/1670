using System.Collections.Generic;

namespace ShoppingOnline.Models
{
    public class Cart
    {
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
