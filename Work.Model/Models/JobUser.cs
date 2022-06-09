using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.Model.Models
{
    [Table("job_user")]
    public class JobUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long job_user_id { get; set; }

        public long job_id { get; set; }
        public string Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string resume { get; set; }
        public DateTime created_at { get; set; }

        [ForeignKey("Id")]
        public virtual ApplicationUser user { get; set; }

        [ForeignKey("job_id")]
        public virtual Job job { get; set; }
    }
}