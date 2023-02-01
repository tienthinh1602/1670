using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace test01MVC.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Display(Name = "Ngay Phat Hanh")]
        public DateTime CreatedDate { get; set; }

        [Range(1, 500)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Xin hay nhap bat dau bang chu hoa")]
        public string? Genre { get; set; }
        public string? Image { get; set; }
    }
}
