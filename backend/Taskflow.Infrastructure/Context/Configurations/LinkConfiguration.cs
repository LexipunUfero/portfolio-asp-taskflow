using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class LinkConfiguration:IEntityTypeConfiguration<LinkEntity>
{
    public void Configure(EntityTypeBuilder<LinkEntity> builder)
    {
        builder
            .HasOne(el=>el.Poject)
            .WithMany(el=>el.Links)
            .HasForeignKey(el=>el.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(el=>el.ProjectAccess)
            .WithMany(el=>el.Links)
            .HasForeignKey(el=>el.ProjectAccessId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}