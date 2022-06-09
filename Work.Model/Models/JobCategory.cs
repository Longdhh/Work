using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Work.Model.Models
{
    [Table("job_category")]
    public class JobCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long job_category_id { get; set; }

        public long job_id { get; set; }
        public long category_id { get; set; }

        [ForeignKey("category_id")]
        public virtual Category category { get; set; }

        [ForeignKey("job_id")]
        public virtual Job job { get; set; }
    }
}