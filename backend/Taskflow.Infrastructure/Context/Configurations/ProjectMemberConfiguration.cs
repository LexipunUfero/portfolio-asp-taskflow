using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class ProjectMemberConfiguration:IEntityTypeConfiguration<ProjectMemberEntity>
{
    public void Configure(EntityTypeBuilder<ProjectMemberEntity> builder)
    {
        builder.HasOne(p => p.Project)
            .WithMany(p => p.ProjectMembers)
            .HasForeignKey(p => p.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.User)
            .WithMany(u => u.ProjectMembers)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(p => p.ProjectAccess)
            .WithMany(p => p.ProjectMembers)
            .HasForeignKey(p => p.ProjectAccessId)
            .OnDelete(DeleteBehavior.SetNull);
        
        
    }
}