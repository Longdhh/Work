using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class CategoryViewModel
    {
        public long category_id { get; set; }
        public string seo_alias { get; set; }
        public string name { get; set; }
        public string seo_title { get; set; }
        public string seo_description { get; set; }
        public string category_logo { get; set; }
        public string category_alt_logo { get; set; }
        public virtual IEnumerable<JobCategoryViewModel> job_categories { get; set; }
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public string modified_by { get; set; }
        public bool status { get; set; }
    }
}