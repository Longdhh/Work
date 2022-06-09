using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("category")]
    public class Category : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long category_id { get; set; }

        [Required]
        [MaxLength(200)]
        public string seo_alias { get; set; }

        [Required]
        [MaxLength(200)]
        public string name { get; set; }

        [MaxLength(200)]
        public string seo_title { get; set; }

        [MaxLength(200)]
        public string seo_description { get; set; }

        [MaxLength(250)]
        public string category_logo { get; set; }

        public virtual IEnumerable<JobCategory> job_categories { get; set; }
    }
}