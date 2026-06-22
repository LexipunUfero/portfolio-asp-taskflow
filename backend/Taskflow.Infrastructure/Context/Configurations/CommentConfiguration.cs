using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class CommentConfiguration:IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder
            .HasOne(el=>el.User)
            .WithMany(el=>el.Comments)
            .HasForeignKey(el=>el.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder
            .HasOne(el=>el.Task)
            .WithMany(el=>el.Comments)
            .HasForeignKey(el=>el.TaskId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(el=>el.File)
            .WithOne(el=>el.Comment)
            .HasForeignKey<CommentEntity>(el=>el.FileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}