using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AddressViewModel
    {
        public long address_id { get; set; }

        public string name { get; set; }
        public string description { get; set; }
        public long? company_id { get; set; }
        public long? job_id { get; set; }
        public DateTime? created_at { get; set; }

        public string created_by { get; set; }

        public DateTime? modified_at { get; set; }

        public string modified_by { get; set; }

        public bool status { get; set; }
    }
}