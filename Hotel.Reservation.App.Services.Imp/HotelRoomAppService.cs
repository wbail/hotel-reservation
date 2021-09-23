using Hotel.Reservation.App.Messages.Common;
using Hotel.Reservation.App.Messages.Response;
using Hotel.Reservation.Models;
using Hotel.Reservation.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Hotel.Reservation.App.Services.Imp
{
    public class HotelRoomAppService : IHotelRoomAppService
    {
        private readonly IHotelRoomService _hotelRoomService;
        private readonly ILogger _logger;

        public HotelRoomAppService(IHotelRoomService hotelRoomService, ILogger<HotelRoomAppService> logger)
        {
            _hotelRoomService = hotelRoomService;
            _logger = logger;
        }

        public async Task<HotelRoomAppResponse> Get()
        {
            var hotelRoomAppResponse = new HotelRoomAppResponse();

            try
            {
                var roomsList = await _hotelRoomService.Get();

                hotelRoomAppResponse.Rooms = roomsList;

                return hotelRoomAppResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ApplicationMessages.ApplicationError, ex);

                return hotelRoomAppResponse;
            }
        }

        public async Task<Room> UpdateAvailability(Guid id, bool isAvailable)
        {
            return await _hotelRoomService.UpdateAvailability(id, isAvailable);
        }

        public async Task<bool> CheckRoomAvailability(Guid id)
        {
            return await _hotelRoomService.CheckRoomAvailability(id);
        }
    }
}

