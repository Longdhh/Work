using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("system_config")]
    public class SystemConfig : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [MaxLength(50)]
        public string name { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string type { get; set; }

        public int value { get; set; }
    }
}