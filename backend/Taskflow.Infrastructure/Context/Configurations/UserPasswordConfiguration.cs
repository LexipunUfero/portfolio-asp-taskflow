using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class UserPasswordConfiguration:IEntityTypeConfiguration<UserPasswordEntity>
{
    public void Configure(EntityTypeBuilder<UserPasswordEntity> builder)
    {
    }
}