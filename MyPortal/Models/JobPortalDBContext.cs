using MyPortal.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyPortal.Models
{
    public class JobPortalDBContext : DbContext
    {
        public JobPortalDBContext() : base("name=JobPortalDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
