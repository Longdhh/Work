using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("district")]
    public class District : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long district_id { get; set; }
        [Required]
        [MaxLength(200)]
        public string name { get; set; }
        public long province_id { get; set; }
        [ForeignKey("province_id")]
        public virtual Province province { get; set; }
        public virtual IEnumerable<Address> addresses { get; set; }
    }
}
