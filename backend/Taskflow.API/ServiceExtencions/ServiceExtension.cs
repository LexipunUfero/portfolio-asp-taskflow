using Taskflow.Application.Interfaces.Repositories;
using Taskflow.Application.Interfaces.Services;
using Taskflow.Application.IO;
using Taskflow.Application.Service;
using Taskflow.Application.Services;
using Taskflow.Application.Validators;
using Taskflow.Infrastructure.Repositories;

namespace Taskflow.ServiceExtencions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<ILinkRepository, LinkRepository>();
        services.AddScoped<IMarkdownRepository, MarkdownRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IProjectAccessRepository, ProjectAccessRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ILinkService, LinkService>();
        services.AddScoped<IMarkdownService, MarkdownService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IProjectAccessService, ProjectAccessService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IUserService, UserService>();
        
        services.AddScoped<FileManager>();
        services.AddScoped<HashManager>();
        services.AddScoped<JwtGenerator>();
        services.AddScoped<LinkManager>();

        return services;
    }
}