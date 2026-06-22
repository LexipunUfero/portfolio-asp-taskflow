using Taskflow.Application.Validators;
using Taskflow.Domain.Models.Configs;

namespace Taskflow.ServiceExtencions;

public static class ConfigExtension
{
    public static IServiceCollection AddConfigs(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ErrorMessages>(configuration.GetSection("ErrorMessages"));
        services.Configure<FileConfigs>(configuration.GetSection("FileConfigs"));
        services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
        services.Configure<LinkConfigs>(configuration.GetSection("LinkConfigs"));
        services.Configure<ProjectConfigs>(configuration.GetSection("ProjectConfigs"));

        return services;
    }
}