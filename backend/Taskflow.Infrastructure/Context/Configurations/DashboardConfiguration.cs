using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class DashboardConfiguration:IEntityTypeConfiguration<DashboardEntity>
{
    public void Configure(EntityTypeBuilder<DashboardEntity> builder)
    {
        builder
            .HasOne(el=>el.Project)
            .WithMany(el=>el.Dasboards)
            .HasForeignKey(el=>el.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}