using System.ComponentModel.DataAnnotations;

namespace DisplayImgDemo.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
      //[StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
      //[StringLength(100)]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter gender")]

        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter position")]

        public string Position { get; set; }

        [Required(ErrorMessage = "Please enter office")]
        public string Office { get; set; }
        [Required(ErrorMessage = "Please enter salary")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Please enter profile picture")]
        public string ProfilePicture { get; set; }
    }
}
