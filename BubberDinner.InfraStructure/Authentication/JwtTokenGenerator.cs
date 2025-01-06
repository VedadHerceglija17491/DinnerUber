using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;



namespace BubberDinner.InfraStructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private const string SecretKey = "super-secret-keysuper-secret-key"; // Use a secure key and store it securely.
    private const string Issuer = "BuberDinner";

    private readonly IDateTimeProvider _IDateTimeProvider;
    private readonly BubberSettings _settings;

    public JwtTokenGenerator(IDateTimeProvider IDateTimeProvider, IOptions<BubberSettings> options)
    {
        _IDateTimeProvider = IDateTimeProvider;
        _settings = options.Value;
    }

  
  public string GenerateToken(Guid userId, string firstName, string lastName)
  {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, firstName + " " + lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString())
            };

            var token = new JwtSecurityToken(
            issuer: Issuer,
            expires: _IDateTimeProvider.UtcNow.AddHours(1),
            claims: claims,
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
  }
}