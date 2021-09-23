using FluentAssertions;
using Hotel.Reservation.App.Services.Imp;
using Hotel.Reservation.Models;
using Hotel.Reservation.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
 
namespace Hotel.Reservation.App.Services.Tests
{
    public class HotelRoomAppServiceTests
    {
        public HotelRoomAppServiceTests()
        {
            _hotelRoomServiceMock = new Mock<IHotelRoomService>();
            _logger = new Mock<ILogger<HotelRoomAppService>>();
 
            _hotelRoomAppService = new HotelRoomAppService(_hotelRoomServiceMock.Object, _logger.Object);
        }
 
        private readonly HotelRoomAppService _hotelRoomAppService;
        private readonly Mock<IHotelRoomService> _hotelRoomServiceMock;
        private readonly Mock<ILogger<HotelRoomAppService>> _logger;
 
        [Fact]
        public async Task CheckRoomAvailability_RoomIsAvailable_ReturnsTrue()
        {
            var id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5");
 
            _hotelRoomServiceMock.Setup(x => x.CheckRoomAvailability(id)).ReturnsAsync(true);
 
            var result = await _hotelRoomAppService.CheckRoomAvailability(id);
 
            result.Should().BeTrue();
        }
 
        [Fact]
        public async Task CheckRoomAvailability_RoomNotIsAvailable_ReturnsFalse()
        {
            var id = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13");
 
            _hotelRoomServiceMock.Setup(x => x.CheckRoomAvailability(id)).ReturnsAsync(false);
 
            var result = await _hotelRoomAppService.CheckRoomAvailability(id);
 
            result.Should().BeFalse();
        }
 
        [Fact]
        public async Task UpdateAvailability_RoomIsAvailable_ReturnsRoomReserved()
        {
            var room = new Room
            {
                Id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5"),
                IsAvailable = false
            };
 
            var mockResult = _hotelRoomServiceMock.Setup(x => x.UpdateAvailability(room.Id, false)).ReturnsAsync(room);
 
            var result = await _hotelRoomAppService.UpdateAvailability(room.Id, false);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task UpdateAvailability_RoomNotIsAvailable_ReturnsRoomAvailable()
        {
            var room = new Room
            {
                Id = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                IsAvailable = true
            };
 
            var mockResult = _hotelRoomServiceMock.Setup(x => x.UpdateAvailability(room.Id, true)).ReturnsAsync(room);
 
            var result = await _hotelRoomAppService.UpdateAvailability(room.Id, true);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Get_Rooms_ReturnsListOfRooms()
        {
            var rooms = new List<Room>
            {
                new Room
                {
                    Id = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                    IsAvailable = false
                },
                new Room
                {
                    Id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5"),
                    IsAvailable = true
                }
            };
 
 
            var mockResult = _hotelRoomServiceMock.Setup(x => x.Get()).ReturnsAsync(rooms);
 
            var result = await _hotelRoomAppService.Get();
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Get_Rooms_ReturnsError()
        {
            _hotelRoomServiceMock.Setup(x => x.Get()).ThrowsAsync(new Exception());
 
            var result = await _hotelRoomAppService.Get();
 
            result.Rooms.Should().BeNull();
        }
    }
}