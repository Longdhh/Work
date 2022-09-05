using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class CountryViewModel
    {
        public long country_id { get; set; }
        public string name { get; set; }
        public string flag { get; set; }
        public virtual IEnumerable<CompanyViewModel> companies { get; set; }
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public string modified_by { get; set; }
        public bool status { get; set; }
    }
}