using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class ProjectAccessConfiguration:IEntityTypeConfiguration<ProjectAccessEntity>
{
    public void Configure(EntityTypeBuilder<ProjectAccessEntity> builder)
    {
        builder.HasOne(el => el.Project)
            .WithMany(el=>el.ProjectAccesses)
            .HasForeignKey(el => el.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}