using Hotel.Reservation.Infra.Data.Context;
using Hotel.Reservation.Models;
using System;
using System.Linq;

namespace Hotel.Reservation.Infra.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelReservationContext context)
        {
            context.Database.EnsureCreated();

            if (context.HotelReservations.Any())
            {
                return;
            }

            var rooms = new Room[]
            {
                new Room
                {
                    Id = Guid.Parse("18c6a659-31cb-4072-8455-a70267fdfa13"),
                    IsAvailable = false
                },

                new Room
                {
                    Id = Guid.Parse("dcf86a9d-cbac-413e-a86f-12aa9f7162b5"),
                    IsAvailable = true
                },
            };

            var reservations = new HotelReservation[]
             {
                new HotelReservation
                {
                    Id = Guid.NewGuid(),
                    RoomId = rooms[0].Id,
                    UserId = Guid.Parse("e48bc591-e4cd-44bf-9842-40c18fee0f75"),
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2),
                },
             };

            foreach (var room in rooms)
            {
                context.Rooms.Add(room);
            }

            foreach (var reservation in reservations)
            {
                context.HotelReservations.Add(reservation);
            }

            context.SaveChanges();

        }
    }
}