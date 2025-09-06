using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstagramClone.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public required string Username { get; set; }

        public string? ProfilePictureUrl { get; set; }
        public string? ProfileBannerUrl { get; set; }

        [DefaultValue("No bio")]
        public string? Bio { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }

        public virtual ICollection<Follow>? Following { get; set; }

        public virtual ICollection<Follow>? Followers { get; set; }

    }
}
