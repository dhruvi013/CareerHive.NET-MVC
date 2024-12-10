using System.Data.Entity;

public class MyPortalDbContext : DbContext
{
    public DbSet<CandidateRegistration> CandidateRegistrations { get; set; }
}
