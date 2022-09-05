using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("country")]
    public class Country : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long country_id { get; set; }

        [Required]
        [MaxLength(200)]
        public string name { get; set; }
        [MaxLength(200)]
        public string flag { get; set; }
        public virtual IEnumerable<Company> companies { get; set; }
    }
}
