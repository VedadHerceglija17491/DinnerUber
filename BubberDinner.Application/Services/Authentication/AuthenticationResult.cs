using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token);