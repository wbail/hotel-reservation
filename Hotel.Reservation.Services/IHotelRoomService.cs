using Hotel.Reservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Reservation.Services
{
    public interface IHotelRoomService
    {
        Task<List<Room>> Get();
        Task<Room> UpdateAvailability(Guid id, bool isAvailable);
        Task<bool> CheckRoomAvailability(Guid id);
    }
}