using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.Model.Models
{
    [Table("announcement")]
    public class Announcement
    {
        public Announcement()
        {
            announcement_users = new List<AnnouncementUser>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int announcement_id { set; get; }

        [StringLength(250)]
        [Required]
        public string title { set; get; }

        public string content { set; get; }

        public DateTime created_at { get; set; }

        [StringLength(128)]
        public string Id { set; get; }

        [ForeignKey("Id")]
        public virtual ApplicationUser user { get; set; }

        public bool status { get; set; }

        public virtual ICollection<AnnouncementUser> announcement_users { get; set; }
    }
}