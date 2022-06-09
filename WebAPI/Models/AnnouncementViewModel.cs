using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public class AnnouncementViewModel
    {
        public AnnouncementViewModel()
        {
            announcement_users = new List<AnnouncementUserViewModel>();
        }

        public int ID { set; get; }

        public string title { set; get; }
        public string email { set; get; }
        public string resume { set; get; }
        public string phone_number { set; get; }

        public string content { set; get; }

        public DateTime created_at { get; set; }

        public string Id { set; get; }

        public ApplicationUserViewModel user { get; set; }

        public bool status { get; set; }

        public virtual ICollection<AnnouncementUserViewModel> announcement_users { get; set; }
    }
}