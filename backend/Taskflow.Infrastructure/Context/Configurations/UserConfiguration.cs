using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class UserConfiguration:IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasOne(el => el.File)
            .WithOne(el => el.User)
            .HasForeignKey<UserEntity>(x => x.FileId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(el => el.UserPassword)
            .WithOne(el => el.User)
            .HasForeignKey<UserEntity>(x => x.UserPasswordId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}