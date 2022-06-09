using System;

namespace WebAPI.Models
{
    public class HomeSlideViewModel
    {
        public long home_slide_id { get; set; }
        public string home_slide_name { get; set; }
        public int home_slide_order_by { get; set; }
        public string home_slide_image { get; set; }
        public string link { get; set; }
        public bool isShowing { get; set; }
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public string modified_by { get; set; }
        public bool status { get; set; }
    }
}