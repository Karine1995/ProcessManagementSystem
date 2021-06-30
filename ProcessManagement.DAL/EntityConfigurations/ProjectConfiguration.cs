using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.DAL.EntityConfigurations
{
    internal class ProjectConfiguration : EntityConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);

            builder.ToTable("Projects");

            builder.HasKey(p => p.Id)
                .IsClustered()
                .HasName("FK_Projects_Id");

            builder.HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .HasConstraintName("FK_Projects_Users");

            builder.HasMany(p => p.Assignments)
                .WithOne(a => a.Project)
                .HasForeignKey(p => p.ProjectId)
                .HasConstraintName("FK_Assignments_Projects");

            builder.Property(p => p.Description)
                .HasMaxLength(1000);
        }
    }
}
