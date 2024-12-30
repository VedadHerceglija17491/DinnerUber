using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Services;


namespace BubberDinner.InfraStructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private const string SecretKey = "super-secret-keysuper-secret-key"; // Use a secure key and store it securely.
    private const string Issuer = "BuberDinner";

    private readonly IDateTimeProvider _IDateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider IDateTimeProvider)
    {
        _IDateTimeProvider = IDateTimeProvider;
    }

  
  public string GenerateToken(Guid userId, string firstName, string lastName)
  {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
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