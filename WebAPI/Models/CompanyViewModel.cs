using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class CompanyViewModel
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string seo_alias { get; set; }
        public string seo_title { get; set; }
        public string seo_description { get; set; }
        public string description { get; set; }
        public string avatar { get; set; }
        public string banner { get; set; }
        public string fax { get; set; }
        public long? followers { get; set; }
        public bool? is_featured { get; set; }
        public long? province_id { get; set; }
        public string address { get; set; }
        public virtual IEnumerable<JobViewModel> jobs { get; set; }
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public string modified_by { get; set; }
        public bool status { get; set; }
    }
}