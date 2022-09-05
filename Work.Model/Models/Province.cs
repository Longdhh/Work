using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("province")]
    public class Province : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long province_id { get; set; }

        [Required]
        [MaxLength(200)]
        public string seo_alias { get; set; }

        [Required]
        [MaxLength(200)]
        public string name { get; set; }

        [MaxLength(200)]
        public string seo_title { get; set; }

        [MaxLength(500)]
        public string seo_description { get; set; }

        public virtual IEnumerable<ApplicationUser> employees { get; set; }
        public virtual IEnumerable<Job> jobs { get; set; }
        public virtual IEnumerable<Company> companies { get; set; }
        public virtual IEnumerable<District> districts { get; set; }
    }
}