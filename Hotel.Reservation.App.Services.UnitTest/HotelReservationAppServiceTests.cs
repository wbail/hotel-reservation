using AutoMapper;
using FluentAssertions;
using Hotel.Reservation.App.Mappers;
using Hotel.Reservation.App.Messages.Request;
using Hotel.Reservation.App.Messages.Response;
using Hotel.Reservation.App.Services.Imp;
using Hotel.Reservation.Models;
using Hotel.Reservation.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
 
namespace Hotel.Reservation.App.Services.UnitTest
{
    public class HotelReservationAppServiceTests
    {
        public HotelReservationAppServiceTests()
        {
            _hotelReservationServiceMock = new Mock<IHotelReservationService>();
            _hotelRoomAppServiceMock = new Mock<IHotelRoomAppService>();
            _loggerMock = new Mock<ILogger<HotelReservationAppService>>();
            _hotelReservationAppResponseMock = new Mock<HotelReservationAppResponse>();
 
            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new HotelReservationMapper());
            });
 
            var mapper = config.CreateMapper();
 
            _hotelReservationAppService = new HotelReservationAppService(_hotelReservationServiceMock.Object, _hotelRoomAppServiceMock.Object, mapper, _loggerMock.Object, _hotelReservationAppResponseMock.Object);
        }
 
        private readonly HotelReservationAppService _hotelReservationAppService;
        private readonly Mock<HotelReservationAppResponse> _hotelReservationAppResponseMock;
        private readonly Mock<IHotelReservationService> _hotelReservationServiceMock;
        private readonly Mock<IHotelRoomAppService> _hotelRoomAppServiceMock;
        private readonly Mock<ILogger<HotelReservationAppService>> _loggerMock;
 
        [Fact]
        public async Task Delete_ReservationExists_RetunsCanceledReservation()
        {
            var id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5");
 
            var hotelReservation = new HotelReservation
            {
                Id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5"),
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                StartDate = DateTime.Parse("2021-09-23 17:01:32.2440000"),
                EndDate = DateTime.Parse("2021-09-24 17:01:32.2440000"),
            };
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.Delete(id)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.Delete(id);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Delete_ReservationNotExists_RetunsMessage()
        {
            var id = Guid.Parse("73a2677c-d551-4925-80d8-855fac6ccdc0");
 
            HotelReservation hotelReservation = null;
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.Delete(id)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.Delete(id);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Delete_Error_RetunsException()
        {
            var id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5");
 
            _hotelReservationServiceMock.Setup(x => x.Delete(id)).ThrowsAsync(new Exception());
 
            var result = await _hotelReservationAppService.Delete(id);
 
            result.HotelReservation.Should().BeNull();
        }
 
        [Fact]
        public async Task Get_ReservationExists_RetunsReservation()
        {
            var id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5");
 
            var hotelReservation = new HotelReservation
            {
                Id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5"),
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                StartDate = DateTime.Parse("2021-09-23 17:01:32.2440000"),
                EndDate = DateTime.Parse("2021-09-24 17:01:32.2440000"),
            };
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.Get(id)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.Get(id);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Get_ReservationNotExists_RetunsMessage()
        {
            var id = Guid.Parse("262d83a3-856d-4ff5-8b43-4bb6f1a642bb");
 
            HotelReservation hotelReservation = null;
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.Get(id)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.Get(id);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Get_Error_RetunsException()
        {
            var id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5");
 
            _hotelReservationServiceMock.Setup(x => x.Get(id)).ThrowsAsync(new Exception());
 
            var result = await _hotelReservationAppService.Get(id);
 
            result.HotelReservation.Should().BeNull();
        }
 
        [Fact]
        public async Task GetByUserId_ReservationExists_RetunsReservation()
        {
            var id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5");
 
            var hotelReservation = new HotelReservation
            {
                Id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5"),
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                StartDate = DateTime.Parse("2021-09-23 17:01:32.2440000"),
                EndDate = DateTime.Parse("2021-09-24 17:01:32.2440000"),
            };
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.GetByUserId(id)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.GetByUserId(id);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task GetByUserId_ReservationNotExists_RetunsMessage()
        {
            var id = Guid.Parse("262d83a3-856d-4ff5-8b43-4bb6f1a642bb");
 
            HotelReservation hotelReservation = null;
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.GetByUserId(id)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.GetByUserId(id);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task GetByUserId_Error_RetunsException()
        {
            var id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5");
 
            _hotelReservationServiceMock.Setup(x => x.GetByUserId(id)).ThrowsAsync(new Exception());
 
            var result = await _hotelReservationAppService.GetByUserId(id);
 
            result.HotelReservation.Should().BeNull();
        }
 
        [Fact]
        public async Task Patch_ReservationExists_RetunsReservation()
        {
            var hotelReservationAppRequest = new HotelReservationAppRequest
            {
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                StartDate = DateTime.Parse("2021-09-23 17:01:32.2440000"),
                EndDate = DateTime.Parse("2021-09-24 17:01:32.2440000"),
            };
 
            var hotelReservation = new HotelReservation
            {
                Id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5"),
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                StartDate = DateTime.Parse("2021-09-23 17:01:32.2440000"),
                EndDate = DateTime.Parse("2021-09-24 17:01:32.2440000"),
            };
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.Patch(hotelReservation)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.Patch(hotelReservationAppRequest);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Patch_ReservationNotExists_RetunsMessage()
        {
            HotelReservation hotelReservation = null;
 
            var hotelReservationAppRequest = new HotelReservationAppRequest
            {
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                StartDate = DateTime.Parse("2021-09-23 17:01:32.2440000"),
                EndDate = DateTime.Parse("2021-09-24 17:01:32.2440000"),
            };
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.Patch(hotelReservation)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.Patch(hotelReservationAppRequest);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Patch_Error_RetunsException()
        {
            HotelReservation hotelReservation = null;
 
            HotelReservationAppRequest hotelReservationAppRequest = null;
 
            _hotelReservationServiceMock.Setup(x => x.Patch(hotelReservation)).ThrowsAsync(new Exception());
 
            var result = await _hotelReservationAppService.Patch(hotelReservationAppRequest);
 
            result.HotelReservation.Should().BeNull();
        }
 
        [Fact]
        public async Task Post_ReservationExists_RetunsReservation()
        {
            var hotelReservationAppRequest = new HotelReservationAppRequest
            {
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                StartDate = DateTime.Parse("2021-09-23 17:01:32.2440000"),
                EndDate = DateTime.Parse("2021-09-24 17:01:32.2440000"),
            };
 
            var hotelReservation = new HotelReservation
            {
                Id = Guid.Parse("DCF86A9D-CBAC-413E-A86F-12AA9F7162B5"),
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                StartDate = DateTime.Parse("2021-09-23 17:01:32.2440000"),
                EndDate = DateTime.Parse("2021-09-24 17:01:32.2440000"),
            };
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.Post(hotelReservationAppRequest)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.Post(hotelReservationAppRequest);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Post_ReservationNotExists_RetunsMessage()
        {
            HotelReservation hotelReservation = null;
 
            var hotelReservationAppRequest = new HotelReservationAppRequest
            {
                UserId = Guid.Parse("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                StartDate = DateTime.Parse("2021-09-23 17:01:32.2440000"),
                EndDate = DateTime.Parse("2021-09-24 17:01:32.2440000"),
            };
 
            var mockResult = _hotelReservationServiceMock.Setup(x => x.Post(hotelReservationAppRequest)).ReturnsAsync(hotelReservation);
 
            var result = await _hotelReservationAppService.Post(hotelReservationAppRequest);
 
            result.Should().Equals(mockResult);
        }
 
        [Fact]
        public async Task Post_Error_RetunsException()
        {
            HotelReservation hotelReservation = null;
 
            HotelReservationAppRequest hotelReservationAppRequest = null;
 
            _hotelReservationServiceMock.Setup(x => x.Post(hotelReservationAppRequest)).ThrowsAsync(new Exception());
 
            var result = await _hotelReservationAppService.Post(hotelReservationAppRequest);
 
            result.HotelReservation.Should().BeNull();
        }
    }
}