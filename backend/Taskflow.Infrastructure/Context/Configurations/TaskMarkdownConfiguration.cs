using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class TaskMarkdownConfiguration:IEntityTypeConfiguration<TaskMarkDownEntity>
{
    public void Configure(EntityTypeBuilder<TaskMarkDownEntity> builder)
    {
        builder.HasOne(el => el.Task)
            .WithMany(el=>el.Markdowns)
            .HasForeignKey(el => el.TaskId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(el=>el.Markdown)
            .WithMany(el=>el.Tasks)
            .HasForeignKey(el=>el.MarkDownId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasKey(el => new { el.TaskId, el.MarkDownId });
    }
}