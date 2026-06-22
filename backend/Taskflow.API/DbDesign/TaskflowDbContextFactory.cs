using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Taskflow.Infrastructure.Context;

namespace Taskflow.DbDesign;

public class TaskflowDbContextFactory: IDesignTimeDbContextFactory<TaskflowDbContext>
{
    public TaskflowDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TaskflowDbContext>();

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        optionsBuilder.UseMySql(
            connectionString,
            ServerVersion.AutoDetect(connectionString)
        );

        return new TaskflowDbContext(optionsBuilder.Options);
    }
}