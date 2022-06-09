using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.Model.Models
{
    [Table("welfare")]
    public class Welfare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long welfare_id { get; set; }

        public long job_id { get; set; }
        public long welfare_type_id { get; set; }

        [MaxLength(200)]
        public string description { get; set; }

        [ForeignKey("welfare_type_id")]
        public virtual WelfareType welfare_type { get; set; }

        [ForeignKey("job_id")]
        public virtual Job job { get; set; }
    }
}