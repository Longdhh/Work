using System;
using System.ComponentModel.DataAnnotations;

namespace Work.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? created_at { get; set; }

        [MaxLength(200)]
        public string created_by { get; set; }

        public DateTime? modified_at { get; set; }

        [MaxLength(200)]
        public string modified_by { get; set; }

        [Required]
        public bool status { get; set; }
    }
}