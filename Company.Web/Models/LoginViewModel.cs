using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Invalid Format For Email ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required ")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
