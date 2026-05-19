using Taskflow.Application.Mappers;

namespace Taskflow.ServiceExtencions;

public static class MapperExtenstion
{
    public static IServiceCollection AddMapping(
        this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<CommentMapping>();
            cfg.AddProfile<DashboardMapping>();
            cfg.AddProfile<LinkMapping>();
            cfg.AddProfile<MarkdownMapping>();
            cfg.AddProfile<MemberMapping>();
            cfg.AddProfile<ProjectAccessMapping>();
            cfg.AddProfile<ProjectMapping>();
            cfg.AddProfile<TaskMapping>();
            cfg.AddProfile<UserMapping>();
        }, typeof(Program).Assembly);
        
        return services;
    }
}