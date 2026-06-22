using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Entities;

namespace Taskflow.Infrastructure.Context.Configurations;

public class ProjectConfiguration:IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        
    }
}