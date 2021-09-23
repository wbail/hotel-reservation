using Hotel.Reservation.Infra.Data.Repositories;
using Hotel.Reservation.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Reservation.Services.Imp
{
    public class HotelRoomService : IHotelRoomService
    {
        private readonly IHotelRoomRepository _hotelRoomRepository;

        public HotelRoomService(IHotelRoomRepository hotelRoomRepository)
        {
            _hotelRoomRepository = hotelRoomRepository;
        }

        public async Task<bool> CheckRoomAvailability(Guid id)
        {
            return await _hotelRoomRepository.CheckRoomAvailability(id);
        }

        public async Task<List<Room>> Get()
        {
            return await _hotelRoomRepository.Get();
        }

        public async Task<Room> UpdateAvailability(Guid id, bool isAvailable)
        {
            return await _hotelRoomRepository.UpdateAvailability(id, isAvailable);
        }
    }
}