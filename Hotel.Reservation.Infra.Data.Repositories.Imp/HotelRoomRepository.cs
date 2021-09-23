using Hotel.Reservation.Infra.Data.Context;
using Hotel.Reservation.Infra.Data.Repositories;
using Hotel.Reservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Reservation.Infra.Data.Respositories.Imp
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly HotelReservationContext _hotelReservationContext;

        public HotelRoomRepository(HotelReservationContext hotelReservationContext)
        {
            _hotelReservationContext = hotelReservationContext;
        }

        public async Task<bool> CheckRoomAvailability(Guid id)
        {
            var roomFromDatabase = await GetRoomById(id);

            if (roomFromDatabase.IsAvailable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Room>> Get()
        {
            return await _hotelReservationContext.Rooms.ToListAsync();
        }

        public async Task<Room> GetRoomById(Guid id)
        {
            return await _hotelReservationContext.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Room> UpdateAvailability(Guid id, bool isAvailable)
        {
            var roomFromDatabase = await GetRoomById(id);

            if (roomFromDatabase != null)
            {
                roomFromDatabase.IsAvailable = isAvailable;

                await _hotelReservationContext.SaveChangesAsync();
            }

            return roomFromDatabase;
        }
    }
}
