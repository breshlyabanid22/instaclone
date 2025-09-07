using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstagramClone.Models
{
    public class Follow
    {
        [Key]
        public int FollowId { get; set; }


        [ForeignKey("Follower")]
        public string? FollowerId { get; set; }

        [ForeignKey("Followee")]
        public string? FolloweeId { get; set; }

        public virtual User? Follower { get; set; }

        public virtual User? Followee { get; set; }
    }
}
