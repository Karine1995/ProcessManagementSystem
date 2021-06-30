using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.DAL.EntityConfigurations
{
    internal class UserConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users");

            builder.HasKey(u => u.Id)
                .IsClustered()
                .HasName("PK_Users_Id");

            builder.HasOne(u => u.Team)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.TeamId)
                .HasConstraintName("FK_Users_Teams");

            builder.HasIndex(u => u.Username)
                .IsUnique()
                .HasDatabaseName("UK_Users_Username");

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(u => u.Type)
                .IsRequired()
                .HasColumnType("smallint");
        }
    }
}
