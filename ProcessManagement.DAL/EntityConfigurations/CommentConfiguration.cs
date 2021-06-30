using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.Entities.Models;

namespace ProcessManagement.DAL.EntityConfigurations
{
    internal class CommentConfiguration : EntityConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.ToTable("Comments");

            builder.HasKey(c => c.Id)
                .IsClustered()
                .HasName("PK_Comments_Id");

            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Comments_Users");

            builder.Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
