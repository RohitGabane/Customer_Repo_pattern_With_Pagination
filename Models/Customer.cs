using System.ComponentModel.DataAnnotations;

namespace Customer_Repo_Pattern.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } = 0;

        [Required(ErrorMessage = "First Name is required")]

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{3,}$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Enter 10 digit number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Enter a valid 10-digit number")]
        public string PhoneNumber { get; set; }
    }
}
