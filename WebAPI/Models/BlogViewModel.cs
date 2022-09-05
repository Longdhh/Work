using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class BlogViewModel
    {

        public long blog_id { get; set; }
        public string description { get; set; }
        public string seo_alias { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string seo_title { get; set; }
        public string seo_description { get; set; }
        public long? blog_category_id { get; set; }
        public DateTime? created_at { get; set; }

        public string created_by { get; set; }

        public DateTime? modified_at { get; set; }

        public string modified_by { get; set; }

        public bool status { get; set; }
    }
}