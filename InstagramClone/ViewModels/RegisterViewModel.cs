using System.ComponentModel.DataAnnotations;

namespace InstagramClone.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Fullname must be at least 3 characters.")]
        public required string FullName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        public string? Bio { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }
    }
}
