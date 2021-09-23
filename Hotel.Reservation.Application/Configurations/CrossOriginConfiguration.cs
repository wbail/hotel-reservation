using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Reservation.Application.Configurations
{
    internal static class CrossOriginConfiguration
    {
        public static IServiceCollection AddCrossOrigin(this IServiceCollection services, string corsPolicyName)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                    builder => builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetIsOriginAllowed(_ => true));
            });
        }
    }
}