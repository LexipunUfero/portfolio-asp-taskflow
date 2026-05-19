using Microsoft.EntityFrameworkCore;
using Taskflow.Infrastructure.Context;

namespace Taskflow.ServiceExtencions;

public static class DbExtension
{
    public static IServiceCollection AddDbInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        
        Console.WriteLine(connectionString);
        services.AddDbContext<TaskflowDbContext>(opt =>
        {
            opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            opt.LogTo(Console.WriteLine, LogLevel.Information);
        });
        
        return services;
    }
}