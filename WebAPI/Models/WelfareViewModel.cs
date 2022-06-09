namespace WebAPI.Models
{
    public class WelfareViewModel
    {
        public long welfare_id { get; set; }

        public long job_id { get; set; }
        public long welfare_type_id { get; set; }
        public string description { get; set; }
        public virtual WelfareTypeViewModel welfare_type { get; set; }
        public virtual JobViewModel job { get; set; }
    }
}