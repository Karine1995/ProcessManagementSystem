using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.DAL.EntityConfigurations
{
    internal class AssignmentConfiguration : EntityConfiguration<Assignment>
    {
        public override void Configure(EntityTypeBuilder<Assignment> builder)
        {
            base.Configure(builder);

            builder.ToTable("Assignments");

            builder.HasKey(a => a.Id)
                .IsClustered()
                .HasName("PK_Assignments_Id");

            builder.HasOne(a => a.CreatedByUser)
                .WithMany(a => a.CreatedAssignments)
                .HasForeignKey(a => a.CreatedById)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Users_CreatedAssigments");

            builder.HasOne(a => a.Assignee)
                .WithMany(a => a.Assignments)
                .HasForeignKey(a => a.AssigneeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Users_Assigments");

            builder.HasOne(a => a.Project)
                .WithMany(p => p.Assignments)
                .HasForeignKey(a => a.ProjectId)
                .HasConstraintName("FK_Assignments_Projects");

            builder.HasMany(a => a.Comments)
                .WithOne(c => c.Assignment)
                .HasForeignKey(c => c.AssignmentId)
                .HasConstraintName("FK_Comments_Assignmnets");

            builder.Property(a => a.Status)
                .IsRequired()
                .HasColumnType("smallint");

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(a => a.Description)
                .IsRequired(false)
                .HasMaxLength(1000);
        }
    }
}
