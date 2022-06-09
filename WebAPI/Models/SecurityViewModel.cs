using System;

namespace WebAPI.Models
{
    public class SecurityViewModel
    {
        public long security_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public string modified_by { get; set; }
        public bool status { get; set; }
    }
}