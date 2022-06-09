using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("security")]
    public class Security : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long security_id { get; set; }

        [MaxLength(200)]
        public string title { get; set; }

        [MaxLength(1000)]
        public string description { get; set; }
    }
}