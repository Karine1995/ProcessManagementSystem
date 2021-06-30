using Microsoft.EntityFrameworkCore;
using ProcessManagement.Entities.Models;
using System.Reflection;

namespace ProcessManagement.DAL.Infrastructure
{
    public class ProcessManagementDbContext : DbContext
    {
        public ProcessManagementDbContext(DbContextOptions<ProcessManagementDbContext> options)
          : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
