using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.DAL.EntityConfigurations
{
    internal class TeamConfiguration : EntityConfiguration<Team>
    {
        public override void Configure(EntityTypeBuilder<Team> builder)
        {
            base.Configure(builder);

            builder.ToTable("Teams");

            builder.HasKey(t => t.Id)
                .IsClustered()
                .HasName("PK_Teams_Id");

            builder.HasIndex(t => t.Name)
                .IsUnique()
                .HasDatabaseName("UK_Teams_Name");

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(25);
        }
    }
}
