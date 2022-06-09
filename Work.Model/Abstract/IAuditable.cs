using System;

namespace Work.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? created_at { get; set; }
        string created_by { get; set; }
        DateTime? modified_at { get; set; }
        string modified_by { get; set; }

        bool status { get; set; }
    }
}