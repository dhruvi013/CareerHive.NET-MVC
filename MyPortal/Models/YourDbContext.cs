// Models/YourDbContext.cs
using System.Data.Entity;

namespace MyPortal.Models
{
    public class YourDbContext : DbContext
    {
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<CandidateRegistration> CandidateRegistrations { get; set; }

        // Other DbSets can go here
    }
}
