using Hotel.Reservation.Models;
using System.Collections.Generic;

namespace Hotel.Reservation.App.Messages.Response
{
    public class HotelRoomAppResponse
    {
        public List<Room> Rooms { get; set; }
    }
}