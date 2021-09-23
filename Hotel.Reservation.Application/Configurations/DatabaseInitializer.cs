using Hotel.Reservation.Infra.Data;
using Hotel.Reservation.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Hotel.Reservation.Application.Configurations
{
    public static class DatabaseInitializer
    {
        public static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<HotelReservationContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred creating the DB.");
                }
            }
        }
    }
}