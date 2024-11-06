using System.ComponentModel.DataAnnotations;
using RelationshipWebsiteV2.Shared;
using RelationshipWebsiteV2.Shared.CustomAttributes;
namespace RelationshipWebsiteV2.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength( 20, MinimumLength = 7 ,  ErrorMessage = "Username must be between 7 and 20 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z]).*$", ErrorMessage = "Password must contain at least one uppercase letter.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Range(18 , 80 , ErrorMessage =  "Age must be between 18 and 80.")]


        [MinAge(18)]
        public DateOnly? Birthdate { get; set; }


    }
}
