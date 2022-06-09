using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class WelfareTypeViewModel
    {
        public long welfare_type_id { get; set; }
        public string welfare_type_logo { get; set; }
        public string seo_alias { get; set; }
        public string name { get; set; }
        public string seo_title { get; set; }
        public string seo_description { get; set; }
        public virtual IEnumerable<WelfareViewModel> welfares { get; set; }
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public string modified_by { get; set; }
        public bool status { get; set; }
    }
}