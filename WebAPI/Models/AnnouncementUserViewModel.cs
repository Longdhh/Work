namespace WebAPI.Models
{
    public class AnnouncementUserViewModel
    {
        public int announcement_id { get; set; }

        public string id { get; set; }

        public bool has_read { get; set; }

        public virtual ApplicationUserViewModel user { get; set; }

        public virtual AnnouncementViewModel announcement { get; set; }
    }
}