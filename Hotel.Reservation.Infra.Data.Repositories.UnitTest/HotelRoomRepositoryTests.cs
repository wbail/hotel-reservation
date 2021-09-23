using FluentAssertions;
using Hotel.Reservation.Infra.Data.Context;
using Hotel.Reservation.Infra.Data.Respositories.Imp;
using Hotel.Reservation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;
 
namespace Hotel.Reservation.Infra.Data.Repositories.UnitTest
{
    public class HotelRoomRepositoryTests
    {
        public HotelRoomRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<HotelReservationContext>()
                .UseInMemoryDatabase(databaseName: "HotelReservation")
                .Options;
        }
 
        private readonly DbContextOptions<HotelReservationContext> _options;
 
        [Fact]
        public async Task CheckRoomAvailability_RoomAvailable_ReturnTrue()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var room = new Room
                {
                    Id = Guid.Parse("f2f67c73-c97e-40a2-ba9d-f4c875b8d75d"),
                    IsAvailable = true
                };
 
                context.Rooms.Add(room);
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var id = Guid.Parse("f2f67c73-c97e-40a2-ba9d-f4c875b8d75d");
                var hotelRoomRepository = new HotelRoomRepository(context);
                var isAvailable = await hotelRoomRepository.CheckRoomAvailability(id);
 
                isAvailable.Should().BeTrue();
 
                await context.DisposeAsync();
            }
        }
 
        [Fact]
        public async Task CheckRoomAvailability_RoomNotAvailable_ReturnFalse()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var room = new Room
                {
                    Id = Guid.Parse("fb920cbe-9081-46a0-b846-5763dd841528"),
                    IsAvailable = false
                };
 
                context.Rooms.Add(room);
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var id = Guid.Parse("fb920cbe-9081-46a0-b846-5763dd841528");
                var hotelRoomRepository = new HotelRoomRepository(context);
                var isAvailable = await hotelRoomRepository.CheckRoomAvailability(id);
 
                isAvailable.Should().BeFalse();
 
                await context.DisposeAsync();
            }
        }
 
        [Fact]
        public async Task Get_Rooms_ReturnListOfRooms()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var roomUnavailable = new Room
                {
                    Id = Guid.Parse("1f7df849-3d1a-4f1c-83fa-6b177924bcd1"),
                    IsAvailable = false
                };
 
                context.Rooms.Add(roomUnavailable);
 
                var roomAvailable = new Room
                {
                    Id = Guid.Parse("e55f999e-0670-4cb1-ba39-e91b1d6cdb1d"),
                    IsAvailable = true
                };
 
                context.Rooms.Add(roomAvailable);
 
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var hotelRoomRepository = new HotelRoomRepository(context);
                var rooms = await hotelRoomRepository.Get();
               
                rooms.Should().HaveCountGreaterThan(1);
 
                await context.DisposeAsync();
            }
        }
 
        [Fact]
        public async Task GetRoomById_Room_ReturnARoom()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var room = new Room
                {
                    Id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5"),
                    IsAvailable = true
                };
 
                context.Rooms.Add(room);
 
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5");
                var hotelRoomRepository = new HotelRoomRepository(context);
                var room = await hotelRoomRepository.GetRoomById(id);
 
                room.Should().NotBeNull();
                room.Should().BeOfType<Room>();
 
                await context.DisposeAsync();
            }
        }
 
        [Fact]
        public async Task UpdateAvailability_Room_ReturnRoomUnavailable()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var room = new Room
                {
                    Id = Guid.Parse("77c155f0-bff5-4278-9330-5596e448eda0"),
                    IsAvailable = true
                };
 
                context.Rooms.Add(room);
 
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var id = Guid.Parse("77c155f0-bff5-4278-9330-5596e448eda0");
                var hotelRoomRepository = new HotelRoomRepository(context);
                var room = await hotelRoomRepository.UpdateAvailability(id, false);
 
                room.Should().NotBeNull();
                room.Should().BeOfType<Room>();
                room.IsAvailable.Should().BeFalse();
 
                await context.DisposeAsync();
            }
        }
 
        [Fact]
        public async Task UpdateAvailability_Room_ReturnRoomAvailable()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var room = new Room
                {
                    Id = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                    IsAvailable = false
                };
 
                context.Rooms.Add(room);
 
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var id = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13");
                var hotelRoomRepository = new HotelRoomRepository(context);
                var room = await hotelRoomRepository.UpdateAvailability(id, true);
 
                room.Should().NotBeNull();
                room.Should().BeOfType<Room>();
                room.IsAvailable.Should().BeTrue();
 
                await context.DisposeAsync();
            }
        }
    }
}
 