namespace WebAPI.Models
{
    public class JobCategoryViewModel
    {
        public long job_category_id { get; set; }

        public long job_id { get; set; }
        public long category_id { get; set; }
        public virtual CategoryViewModel category { get; set; }
        public virtual JobViewModel job { get; set; }
    }
}