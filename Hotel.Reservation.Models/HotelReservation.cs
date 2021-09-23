using System;

namespace Hotel.Reservation.Models
{
    public class HotelReservation
    {
        public HotelReservation()
        {

        }

        public HotelReservation(Guid userId, Guid roomId, DateTime startDate, DateTime endDate)
        {
            UserId = userId;
            RoomId = roomId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}