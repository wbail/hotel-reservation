using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Hotel.Reservation.Application.Configurations
{
    internal static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, string title, string version)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = title,
                    Version = version
                });
            });
        }
    }
}