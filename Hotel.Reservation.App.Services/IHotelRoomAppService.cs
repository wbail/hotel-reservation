using Hotel.Reservation.App.Messages.Response;
using Hotel.Reservation.Models;
using System;
using System.Threading.Tasks;

namespace Hotel.Reservation.App.Services
{
    public interface IHotelRoomAppService
    {
        Task<HotelRoomAppResponse> Get();
        Task<Room> UpdateAvailability(Guid id, bool isAvailable);
        Task<bool> CheckRoomAvailability(Guid id);
    }
}