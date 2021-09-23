using Hotel.Reservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Reservation.Infra.Data.Repositories
{
    public interface IHotelRoomRepository
    {
        Task<List<Room>> Get();

        Task<Room> UpdateAvailability(Guid id, bool isAvailable);

        Task<Room> GetRoomById(Guid id);

        Task<bool> CheckRoomAvailability(Guid id);
    }
}