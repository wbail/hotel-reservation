using Hotel.Reservation.Models;

namespace Hotel.Reservation.App.Messages.Response
{
    public class HotelReservationAppResponse
    {
        public HotelReservationAppResponse()
        {

        }

        public HotelReservationAppResponse(string message, bool reservationStatus, HotelReservation hotelReservation)
        {
            Message = message;
            ReservationStatus = reservationStatus;
            HotelReservation = hotelReservation;
        }

        public string Message { get; set; }
        public bool ReservationStatus { get; set; }
        public HotelReservation HotelReservation { get; set; }
    }
}