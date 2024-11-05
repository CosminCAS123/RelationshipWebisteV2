using System.ComponentModel.DataAnnotations;

namespace RelationshipWebsiteV2.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[A-Z]).*$", ErrorMessage = "Password must contain at least one uppercase letter.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
