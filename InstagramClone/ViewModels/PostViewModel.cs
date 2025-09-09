using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstagramClone.ViewModels
{
    public class PostViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Caption must be less than 50 character.")]
        [DisplayName("Caption")]
        public required string Content { get; set; }

        public string? ImageUrl { get; set; }
    }
}
