using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("home_slide")]
    public class HomeSlide : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long home_slide_id { get; set; }

        [MaxLength(250)]
        public string home_slide_name { get; set; }

        public string home_slide_image { get; set; }
        public int home_slide_order_by { get; set; }

        [Required]
        [MaxLength(250)]
        public string link { get; set; }

        [Required]
        public bool isShowing { get; set; }
    }
}