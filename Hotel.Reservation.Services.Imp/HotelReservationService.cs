using Hotel.Reservation.App.Messages.Request;
using Hotel.Reservation.Infra.Data.Repositories;
using Hotel.Reservation.Models;
using System;
using System.Threading.Tasks;

namespace Hotel.Reservation.Services.Imp
{
    public class HotelReservationService : IHotelReservationService
    {
        private readonly IHotelReservationRepository _hotelReservationRepository;

        public HotelReservationService(IHotelReservationRepository hotelReservationRepository)
        {
            _hotelReservationRepository = hotelReservationRepository;
        }

        public async Task<HotelReservation> Delete(Guid id)
        {
            return await _hotelReservationRepository.Delete(id);
        }

        public async Task<HotelReservation> Get(Guid id)
        {
            return await _hotelReservationRepository.Get(id);
        }

        public async Task<HotelReservation> GetByUserId(Guid userId)
        {
            var hotelReservations = await _hotelReservationRepository.GetByUserId(userId);

            return hotelReservations;
        }

        public async Task<HotelReservation> Patch(HotelReservation hotelReservation)
        {
            return await _hotelReservationRepository.Update(hotelReservation);
        }

        public async Task<HotelReservation> Post(HotelReservationAppRequest hotelReservationAppRequest)
        {
            var hotelReservation = new HotelReservation(hotelReservationAppRequest.UserId, hotelReservationAppRequest.RoomId, hotelReservationAppRequest.StartDate, hotelReservationAppRequest.EndDate);

            await _hotelReservationRepository.Create(hotelReservation);

            return hotelReservation;
        }
    }
}