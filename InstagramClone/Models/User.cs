using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InstagramClone.Models
{
    public class User : IdentityUser
    {   
        public string? ProfilePictureUrl { get; set; }
        public string? ProfileBannerUrl { get; set; }

        [DefaultValue("No bio")]
        public string? Bio { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }

        public virtual ICollection<Follow>? Following { get; set; }

        public virtual ICollection<Follow>? Followers { get; set; }

    }
}
