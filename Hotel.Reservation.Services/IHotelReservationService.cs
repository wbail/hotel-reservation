using Hotel.Reservation.App.Messages.Request;
using Hotel.Reservation.Models;
using System;
using System.Threading.Tasks;

namespace Hotel.Reservation.Services
{
    public interface IHotelReservationService
    {
        Task<HotelReservation> GetByUserId(Guid userId);
        Task<HotelReservation> Get(Guid id);
        Task<HotelReservation> Post(HotelReservationAppRequest hotelReservation);
        Task<HotelReservation> Delete(Guid id);
        Task<HotelReservation> Patch(HotelReservation hotelReservation);
    }
}