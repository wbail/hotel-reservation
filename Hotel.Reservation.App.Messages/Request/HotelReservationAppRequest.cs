using System;

namespace Hotel.Reservation.App.Messages.Request
{
    public class HotelReservationAppRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool ValidateDates()
        {
            return !((StartDate.Date > DateTime.Now) && (EndDate.Date > DateTime.Now) && ((EndDate - StartDate).TotalDays <= 3 && (StartDate - DateTime.Now).TotalDays < 30));
        }
    }
}