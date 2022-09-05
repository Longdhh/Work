using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("public_text")]
    public class PublicText : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long public_text_id { get; set; }
        [Required]
        [MaxLength(200)]
        public string title { get; set; }

        [MaxLength(35000)]
        public string description { get; set; }
    }
}
