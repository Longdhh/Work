using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("term_of_service")]
    public class TermsOfService : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long tos_id { get; set; }

        [MaxLength(200)]
        public string title { get; set; }

        [MaxLength(1000)]
        public string description { get; set; }
    }
}