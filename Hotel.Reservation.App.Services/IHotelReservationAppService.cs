using Hotel.Reservation.App.Messages.Request;
using Hotel.Reservation.App.Messages.Response;
using System;
using System.Threading.Tasks;

namespace Hotel.Reservation.App.Services
{
    public interface IHotelReservationAppService
    {
        Task<HotelReservationAppResponse> GetByUserId(Guid userId);
        Task<HotelReservationAppResponse> Get(Guid id);
        Task<HotelReservationAppResponse> Post(HotelReservationAppRequest hotelReservationAppRequest);
        Task<HotelReservationAppResponse> Patch(HotelReservationAppRequest hotelReservationAppRequest);
        Task<HotelReservationAppResponse> Delete(Guid id);
    }
}