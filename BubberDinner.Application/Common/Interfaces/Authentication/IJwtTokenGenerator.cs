using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User userl);
}