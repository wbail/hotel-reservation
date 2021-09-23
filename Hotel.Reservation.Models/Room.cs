using System;

namespace Hotel.Reservation.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public bool IsAvailable { get; set; }
    }
}