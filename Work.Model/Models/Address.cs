using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("address")]
    public class Address : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long address_id { get; set; }
        [MaxLength(500)]
        public string name { get; set; }
        public long district_id { get; set; }
        [Required]
        [MaxLength(200)]
        public string description { get; set; }
        public string company_id { get; set; }
        public long? job_id { get; set; }
        [ForeignKey("company_id")]
        public virtual Company company { get; set; }
        [ForeignKey("job_id")]
        public virtual Job job { get; set; }

    }
}
