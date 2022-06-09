using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class JobViewModel
    {
        public long job_id { get; set; }
        public string seo_alias { get; set; }
        public string name { get; set; }
        public string seo_title { get; set; }
        public string seo_description { get; set; }
        public string job_requirement { get; set; }
        public string description { get; set; }
        public long company_id { get; set; }
        public DateTime job_end_date { get; set; }
        public long job_view_count { get; set; }
        public long working_type_id { get; set; }
        public long level_id { get; set; }
        public long province_id { get; set; }
        public long salary_range_id { get; set; }
        public string address { get; set; }
        public string Id { get; set; }
        public long job_registed_user { get; set; }
        public virtual SalaryRangeViewModel salary_range { get; set; }
        public virtual ProvinceViewModel province { get; set; }
        public virtual LevelViewModel level { get; set; }
        public virtual CompanyViewModel company { get; set; }
        public virtual WorkingTypeViewModel working_type { get; set; }
        public virtual IEnumerable<WelfareViewModel> welfares { get; set; }
        public virtual IEnumerable<JobCategoryViewModel> job_categories { get; set; }
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public string modified_by { get; set; }
        public bool status { get; set; }
    }
}