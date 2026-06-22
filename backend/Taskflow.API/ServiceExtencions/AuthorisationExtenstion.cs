using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Taskflow.ServiceExtencions;

public static class AuthorisationExtenstion
{
    public static IServiceCollection AddAuthorisactions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
        
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                };
                
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var auth = context.Request.Headers.Authorization.ToString();
                        Console.WriteLine("HOST: " + context.Request.Host);
                        Console.WriteLine("SCHEME: " + context.Request.Scheme);
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Fail");
                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        Console.WriteLine(context.Request.Path);
                        Console.WriteLine("Forbidden");
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        Console.WriteLine("Challange");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context=>
                    {
                        Console.WriteLine("Validated");
                        return Task.CompletedTask;
                    }
                    
                    
                };
            });
        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });
        return services;
    }
}