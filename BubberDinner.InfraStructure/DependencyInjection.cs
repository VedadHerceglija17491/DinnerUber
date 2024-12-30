using Microsoft.Extensions.DependencyInjection;
using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.InfraStructure.Authentication;
using BubberDinner.Application.Common.Interfaces.Services;
using BubberDinner.InfraStructure.Services;

namespace BubberDinner.Infrastructure;

public static class DependencyInjectionc
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            
            return services;
    }
}