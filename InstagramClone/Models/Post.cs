using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstagramClone.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public required string Content { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("User")]
        public required string UserId { get; set; }

        public virtual User? User { get; set; }

    }
}
