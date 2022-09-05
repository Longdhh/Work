using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Work.Model.Abstract;

namespace Work.Model.Models
{
    [Table("company")]
    public class Company : Auditable
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string name { get; set; }

        [MaxLength(200)]
        public string seo_alias { get; set; }

        [MaxLength(200)]
        public string seo_title { get; set; }

        [MaxLength(10000)]
        public string seo_description { get; set; }

        [MaxLength(10000)]
        public string description { get; set; }

        [MaxLength(250)]
        public string avatar { get; set; }

        [MaxLength(250)]
        public string banner { get; set; }

        [MaxLength(50)]
        public string fax { get; set; }

        public string phone_number { get; set; }
        public long? followers { get; set; }
        public bool? is_featured { get; set; }
        public long? country_id { get; set; }
        public long? scale_id { get; set; }
        public virtual ApplicationUser user { get; set; }
        [ForeignKey("country_id")]
        public virtual Country country { get; set; }
        [ForeignKey("scale_id")]
        public virtual Scale scale { get; set; }

        public virtual IEnumerable<Job> jobs { get; set; }
        public virtual IEnumerable<Address> addresses { get; set; }
    }
}