using Microsoft.Extensions.DependencyInjection;
using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.InfraStructure.Authentication;
using BubberDinner.Application.Common.Interfaces.Services;
using BubberDinner.InfraStructure.Services;
using Microsoft.Extensions.Configuration;
using BubberDinner.Application.Common.Interfaces.Persistance;
using BubberDinner.InfraStructure.Persistance;

namespace BubberDinner.Infrastructure;

public static class DependencyInjectionc
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
     ConfigurationManager configuration)
    {
            services.Configure<BubberSettings>(configuration.GetSection("BubberSettings"));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>(); 
            
            
            return services;
    }
}