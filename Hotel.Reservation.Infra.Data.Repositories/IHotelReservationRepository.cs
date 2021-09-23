using Hotel.Reservation.Models;
using System;
using System.Threading.Tasks;

namespace Hotel.Reservation.Infra.Data.Repositories
{
    public interface IHotelReservationRepository
    {
        Task<HotelReservation> Get(Guid id);
        Task<HotelReservation> GetByUserId(Guid userId);
        Task<HotelReservation> Create(HotelReservation hotelReservation);
        Task<HotelReservation> Update(HotelReservation hotelReservation);
        Task<HotelReservation> Delete(Guid id);
    }
}