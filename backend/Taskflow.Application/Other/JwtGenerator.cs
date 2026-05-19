using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Taskflow.Domain.Models.Configs;

namespace Taskflow.Application.Validators;

public class JwtGenerator
{
    private readonly JWTSettings jwtSettings;
    
    public JwtGenerator(IOptions<JWTSettings> jwtSettings)
    {
        this.jwtSettings = jwtSettings.Value;
    }

    public string GetToken(Guid userId)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var claims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString())
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtSettings.ExpireTime),
            signingCredentials: credentials
        );

        return token.ToString();
    }
}