using Hotel.Reservation.Infra.Data.Context;
using Hotel.Reservation.Infra.Data.Repositories;
using Hotel.Reservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Hotel.Reservation.Infra.Data.Respositories.Imp
{
    public class HotelReservationRepository : IHotelReservationRepository
    {
        private readonly HotelReservationContext _hotelReservationContext;

        public HotelReservationRepository(HotelReservationContext hotelReservationContext)
        {
            _hotelReservationContext = hotelReservationContext;
        }

        public async Task<HotelReservation> Delete(Guid id)
        {
            var hotelReservationFromDatabase = await Get(id);

            if (hotelReservationFromDatabase != null)
            {
                _hotelReservationContext.Remove(hotelReservationFromDatabase);
                await _hotelReservationContext.SaveChangesAsync();
            }

            return hotelReservationFromDatabase;
        }

        public async Task<HotelReservation> GetByUserId(Guid userId)
        {
            return await _hotelReservationContext.HotelReservations
               .FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<HotelReservation> Get(Guid id)
        {
            return await _hotelReservationContext.HotelReservations
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HotelReservation> Create(HotelReservation hotelReservation)
        {
            _hotelReservationContext.HotelReservations
                .Add(hotelReservation);

            await _hotelReservationContext.SaveChangesAsync();

            return hotelReservation;
        }

        public async Task<HotelReservation> Update(HotelReservation hotelReservation)
        {
            var hotelReservationFromDatabase = await Get(hotelReservation.Id);

            if (hotelReservationFromDatabase != null)
            {
                _hotelReservationContext.Entry(hotelReservationFromDatabase).CurrentValues.SetValues(hotelReservation);

                await _hotelReservationContext.SaveChangesAsync();
            }

            return hotelReservationFromDatabase;
        }
    }
}