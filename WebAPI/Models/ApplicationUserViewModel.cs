using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class ApplicationUserViewModel
    {
        public string Id { set; get; }
        public string name { get; set; }
        public string seo_title { get; set; }
        public string seo_description { get; set; }
        public string description { get; set; }
        public string avatar { get; set; }
        public string banner { get; set; }
        public string fax { get; set; }
        public long? followers { get; set; }
        public bool? is_featured { get; set; }
        public DateTime? birthday { get; set; }
        public bool? gender { get; set; }
        public long? years_of_experience { get; set; }

        public string last_company { get; set; }

        public long? level_id { set; get; }

        public long? province_id { get; set; }
        public ICollection<JobViewModel> jobs { get; set; }
        public string address { get; set; }
        public DateTime? created_at { get; set; }

        public string created_by { get; set; }

        public DateTime? modified_at { get; set; }

        public string modified_by { get; set; }

        public bool status { get; set; }

        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }
        public string PhoneNumber { set; get; }
        public ICollection<string> roles { get; set; }
    }
}