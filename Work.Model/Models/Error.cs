using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.Model.Models
{
    [Table("error")]
    public class Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long error_id { get; set; }

        public string error_message { get; set; }
        public string stack_trace { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}