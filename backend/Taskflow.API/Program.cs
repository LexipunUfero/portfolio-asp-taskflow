using Microsoft.OpenApi;
using Taskflow.middleware;
using Taskflow.ServiceExtencions;

var builder = WebApplication
    .CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddControllers();

builder.Services
    .AddMapping()
    .AddDbInfrastructure(builder.Configuration)
    .AddConfigs(builder.Configuration)
    .AddAuthorisactions(builder.Configuration)
    .AddServices();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Taskflow API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your token}"
    });

    c.AddSecurityRequirement(document=> new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder
    .Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}
else
{
    app.UseHsts();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<LogMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();