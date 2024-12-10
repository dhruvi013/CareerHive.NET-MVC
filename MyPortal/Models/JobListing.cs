using System;
using System.Collections.Generic;

namespace MyPortal.Models
{
    public class JobListing
    {
        public int Id { get; set; } // Unique identifier for each job
        public string Title { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? PostedDate { get; set; }
    }
}
