using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
