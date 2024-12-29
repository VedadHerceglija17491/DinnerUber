using Microsoft.Extensions.DependencyInjection;
using BubberDinner.Application.Services.Authentication;

namespace BubberDinner.Application;

public static class DependencyInjectionc
{
    public static IServiceCollection AddApplication(this IServiceCollection Services)
    {
            Services.AddScoped<IAuthenticationService, AuthenticationService>();
            return Services;
    }
}