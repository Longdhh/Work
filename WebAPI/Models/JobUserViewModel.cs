using System;

namespace WebAPI.Models
{
    public class JobUserViewModel
    {
        public long job_user_id { get; set; }

        public long job_id { get; set; }
        public string Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string resume { get; set; }
        public DateTime created_at { get; set; }
        public virtual ApplicationUserViewModel user { get; set; }
        public virtual JobViewModel job { get; set; }
    }
}