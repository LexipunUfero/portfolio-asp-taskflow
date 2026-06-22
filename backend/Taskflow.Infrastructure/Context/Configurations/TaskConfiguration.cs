using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class TaskConfiguration:IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.HasOne(el=>el.Dashboard)
            .WithMany(el=>el.Tasks)
            .HasForeignKey(el=>el.DashboardId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(el => el.RowVersion)
            .IsRowVersion();
    }
}