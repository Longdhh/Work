using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.Model.Models
{
    [Table("announcement_user")]
    public class AnnouncementUser
    {
        [Key]
        [Column(Order = 1)]
        public int announcement_id { get; set; }

        [Key]
        [Column(Order = 2)]
        public string id { get; set; }

        public bool has_read { get; set; }

        [ForeignKey("id")]
        public virtual ApplicationUser user { get; set; }

        [ForeignKey("announcement_id")]
        public virtual Announcement announcement { get; set; }
    }
}