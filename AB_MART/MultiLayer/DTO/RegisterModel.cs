using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class RegisterModel
    {
      
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [MaxLength(50)]
        public string State { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
