using FluentAssertions;
using Hotel.Reservation.App.Messages.Request;
using System;
using Xunit;
 
namespace Hotel.Reservation.App.Messages.UnitTest
{
    public class HotelReservationAppRequestTests
    {
        [Fact]
       public void ValidateDates_ValidDates_ReturnFalse()
        {
            var hotelReservationAppRequest = new HotelReservationAppRequest
            {
                RoomId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(2),
            };
 
            var result = hotelReservationAppRequest.ValidateDates();
 
            result.Should().BeFalse();
        }
 
        [Fact]
        public void ValidateDates_InvalidDates_ReturnTrue()
        {
            var hotelReservationAppRequest = new HotelReservationAppRequest
            {
                RoomId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                StartDate = DateTime.Now.AddDays(30),
                EndDate = DateTime.Now.AddDays(33),
            };
 
            var result = hotelReservationAppRequest.ValidateDates();
 
            result.Should().BeTrue();
        }
 
        [Fact]
        public void ValidateDates_InvalidDatesStartDateLessThanToday_ReturnTrue()
        {
            var hotelReservationAppRequest = new HotelReservationAppRequest
            {
                RoomId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                StartDate = DateTime.Now.AddDays(-7),
                EndDate = DateTime.Now.AddDays(1),
            };
 
            var result = hotelReservationAppRequest.ValidateDates();
 
            result.Should().BeTrue();
        }
 
        [Fact]
        public void ValidateDates_TotalDaysGreaterThanThreeDays_ReturnTrue()
        {
            var hotelReservationAppRequest = new HotelReservationAppRequest
            {
                RoomId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(7),
            };
 
            var result = hotelReservationAppRequest.ValidateDates();
 
            result.Should().BeTrue();
        }
    }
}