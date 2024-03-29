﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PublicTextViewModel
    {
        public long public_text_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime? created_at { get; set; }
        public string created_by { get; set; }
        public DateTime? modified_at { get; set; }
        public string modified_by { get; set; }
        public bool status { get; set; }
    }
}