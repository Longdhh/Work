using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("welfare_type")]
    public class WelfareType : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long welfare_type_id { get; set; }

        [MaxLength(250)]
        public string welfare_type_logo { get; set; }

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

        public virtual IEnumerable<Welfare> welfares { get; set; }
    }
}