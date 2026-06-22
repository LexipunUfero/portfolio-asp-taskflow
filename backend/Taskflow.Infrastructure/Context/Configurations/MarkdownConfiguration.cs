using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class MarkdownConfiguration:IEntityTypeConfiguration<MarkdownEntity>
{
    public void Configure(EntityTypeBuilder<MarkdownEntity> builder)
    {
        builder.HasOne(el=>el.Project)
            .WithMany(el=>el.Markdowns)
            .HasForeignKey(el=>el.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}