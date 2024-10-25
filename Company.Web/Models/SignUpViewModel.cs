using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name Is Required ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Invalid Format For Email ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required ")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Is Required ")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password does not match password ")]

        public string ConfirmPassword {  get; set; }
        [Required(ErrorMessage ="Required to Agree")]
        public bool IsAgree { get; set; }

    }
}
