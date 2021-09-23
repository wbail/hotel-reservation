using Hotel.Reservation.Infra.CrossCutting.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 
namespace Hotel.Reservation.Application.Configurations
{
    internal static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            DIFactory.ConfigureDI(services, configuration);
            return services;
        }
    }
}