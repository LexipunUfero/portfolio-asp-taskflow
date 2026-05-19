using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class LinkUserConfiguration:IEntityTypeConfiguration<LinkUserEntity>
{
    public void Configure(EntityTypeBuilder<LinkUserEntity> builder)
    {
        builder
            .HasOne(el=>el.Link)
            .WithMany(el=>el.LinkUsers)
            .HasForeignKey(el=>el.LinkId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(el=>el.User)
            .WithMany(el=>el.LinkUsers)
            .HasForeignKey(el=>el.UserId)
            .OnDelete(DeleteBehavior.SetNull);
        
    }
}