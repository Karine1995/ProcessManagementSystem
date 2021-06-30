using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcessManagement.IdentityServer4.Data.Entities;

namespace ProcessManagement.IdentityServer4.Data
{
    public class ProcessManagementIdentityDbContext : IdentityDbContext<ApplicationUser>

    {
        public ProcessManagementIdentityDbContext(DbContextOptions<ProcessManagementIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
