using Microsoft.EntityFrameworkCore;
using Taskflow.Domain.Entities;
using Taskflow.Infrastructure.Context.Configurations;

namespace Taskflow.Infrastructure.Context;

public class TaskflowDbContext: DbContext
{
    public DbSet<CommentEntity> Comments { get; set; }
    public DbSet<DashboardEntity> Dashboards { get; set; }
    public DbSet<FileEntity> Files { get; set; }
    public DbSet<LinkEntity> Links { get; set; }
    public DbSet<LinkUserEntity> LinkUsers { get; set; }
    public DbSet<MarkdownEntity> Markdowns { get; set; }
    public DbSet<ProjectAccessEntity> ProjectAccesses { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<ProjectMemberEntity> ProjectMembers { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<TaskMarkDownEntity> TaskMarkDowns { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserPasswordEntity> UserPasswords { get; set; }

    public TaskflowDbContext(DbContextOptions<TaskflowDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CommentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DashboardConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(FileConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(LinkConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(LinkUserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(MarkdownConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ProjectAccessConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ProjectConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ProjectMemberConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TaskConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TaskMarkdownConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(UserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(UserPasswordConfiguration).Assembly);
        
    }
}