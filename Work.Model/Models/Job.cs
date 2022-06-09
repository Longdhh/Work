using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("job")]
    public class Job : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long job_id { get; set; }

        [Required]
        [MaxLength(200)]
        public string seo_alias { get; set; }

        [Required]
        [MaxLength(200)]
        public string name { get; set; }

        [MaxLength(200)]
        public string seo_title { get; set; }

        [MaxLength(14500)]
        public string seo_description { get; set; }

        public long? salary_range_id { get; set; }

        [MaxLength(14500)]
        public string job_requirement { get; set; }

        [MaxLength(14500)]
        public string description { get; set; }

        public string Id { get; set; }
        public DateTime? job_end_date { get; set; }
        public long? job_view_count { get; set; }
        public long? working_type_id { get; set; }
        public long? level_id { get; set; }
        public long? province_id { get; set; }
        public string address { get; set; }
        public long job_registed_user { get; set; }

        [ForeignKey("province_id")]
        public virtual Province province { get; set; }

        [ForeignKey("level_id")]
        public virtual Level level { get; set; }

        [ForeignKey("Id")]
        public virtual Company company { get; set; }

        [ForeignKey("working_type_id")]
        public virtual WorkingType working_type { get; set; }

        [ForeignKey("salary_range_id")]
        public virtual SalaryRange salary_range { get; set; }

        public virtual IEnumerable<JobCategory> job_categories { get; set; }
        public virtual IEnumerable<JobUser> job_users { get; set; }
        public virtual IEnumerable<Welfare> welfares { get; set; }
    }
}