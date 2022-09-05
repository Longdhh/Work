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
    [Table("blog")]
    public class Blog : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long blog_id { get; set; }

        [MaxLength(35000)]
        public string description { get; set; }
        [Required]
        [MaxLength(200)]
        public string seo_alias { get; set; }

        [Required]
        [MaxLength(200)]
        public string name { get; set; }
        [MaxLength(200)]
        public string avatar { get; set; }

        [MaxLength(200)]
        public string seo_title { get; set; }

        [MaxLength(1000)]
        public string seo_description { get; set; }
        public long? blog_category_id { get; set; }
        [ForeignKey("blog_category_id")]
        public virtual BlogCategory blog_category { get; set; }

    }
}
