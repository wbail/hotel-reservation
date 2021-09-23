using AutoMapper;
using Hotel.Reservation.App.Mappers;
using Hotel.Reservation.App.Messages.Response;
using Hotel.Reservation.App.Services;
using Hotel.Reservation.App.Services.Imp;
using Hotel.Reservation.Infra.Data.Context;
using Hotel.Reservation.Infra.Data.Repositories;
using Hotel.Reservation.Infra.Data.Respositories.Imp;
using Hotel.Reservation.Services;
using Hotel.Reservation.Services.Imp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Reservation.Infra.CrossCutting.DI
{
    public static class DIFactory
    {
        public static void ConfigureDI(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddOptions();

            #region Application Layer

            services.AddScoped<IHotelReservationAppService, HotelReservationAppService>();
            services.AddScoped<IHotelRoomAppService, HotelRoomAppService>();
            services.AddScoped<HotelReservationAppResponse>();

            #endregion

            #region Service Layer

            services.AddScoped<IHotelReservationService, HotelReservationService>();
            services.AddScoped<IHotelRoomService, HotelRoomService>();

            #endregion

            #region Infrastructure Layer

            services.AddDbContext<HotelReservationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IHotelReservationRepository, HotelReservationRepository>();
            services.AddScoped<IHotelRoomRepository, HotelRoomRepository>();


            #endregion

            #region Private Calls

            services.AddSingleton(RegisterAutoMapper());

            #endregion
        }

        #region Private Methods

        private static IMapper RegisterAutoMapper()
        {
            var mappingConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<HotelReservationMapper>();
            });

            return mappingConfig.CreateMapper();
        }

        #endregion
    }
}