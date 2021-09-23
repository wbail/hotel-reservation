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
    public class HotelReservationRepositoryTests
    {
        public HotelReservationRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<HotelReservationContext>()
                .UseInMemoryDatabase(databaseName: "HotelReservation")
                .Options;
        }
 
        private readonly DbContextOptions<HotelReservationContext> _options;
   
        [Fact]
        public async Task Delete_HotelReservation_ReturnReservationDeleted()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var hotelReservation = new HotelReservation
                {
                    Id = Guid.Parse("13533B81-EC32-4192-B0EC-330910238652"),
                    UserId = Guid.Parse("E48BC591-E4CD-44BF-9842-40C18FEE0F75"),
                    RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2)
                };
 
                context.HotelReservations.Add(hotelReservation);
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var id = Guid.Parse("13533B81-EC32-4192-B0EC-330910238652");
                var hotelReservationRepository = new HotelReservationRepository(context);
                var hotelReservation = await hotelReservationRepository.Delete(id);
 
                hotelReservation.Should().NotBeNull();
                hotelReservation.Should().BeOfType<HotelReservation>();
            }
        }
 
        [Fact]
        public async Task GetByUserId_HotelReservation_ReturnHotelReservation()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var hotelReservation = new HotelReservation
                {
                    Id = Guid.Parse("13533B81-EC32-4192-B0EC-330910238652"),
                    UserId = Guid.Parse("E48BC591-E4CD-44BF-9842-40C18FEE0F75"),
                    RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2)
                };
 
                context.HotelReservations.Add(hotelReservation);
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var id = Guid.Parse("E48BC591-E4CD-44BF-9842-40C18FEE0F75");
                var hotelReservationRepository = new HotelReservationRepository(context);
                var hotelReservation = await hotelReservationRepository.GetByUserId(id);
 
                hotelReservation.Should().NotBeNull();
                hotelReservation.Should().BeOfType<HotelReservation>();
            }
        }
 
        [Fact]
        public async Task Create_HotelReservation_ReturnHotelReservation()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var hotelReservation = new HotelReservation
                {
                    Id = Guid.Parse("7702338a-0aae-48e3-aa6b-72715df3635f"),
                    UserId = Guid.Parse("E48BC591-E4CD-44BF-9842-40C18FEE0F75"),
                    RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2)
                };
 
                var hotelReservationRepository = new HotelReservationRepository(context);
                var newHotelReservation = await hotelReservationRepository.Create(hotelReservation);
 
                newHotelReservation.Should().NotBeNull();
                newHotelReservation.Should().BeOfType<HotelReservation>();
            }
        }
 
        [Fact]
        public async Task Get_HotelReservation_ReturnHotelReservation()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var hotelReservation = new HotelReservation
                {
                    Id = Guid.Parse("7728f432-f93e-4ad9-9f0a-b864cc7c3c3b"),
                    UserId = Guid.Parse("E48BC591-E4CD-44BF-9842-40C18FEE0F75"),
                    RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2)
                };
 
                context.HotelReservations.Add(hotelReservation);
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var id = Guid.Parse("13533B81-EC32-4192-B0EC-330910238652");
                var hotelReservationRepository = new HotelReservationRepository(context);
                var hotelReservation = await hotelReservationRepository.Get(id);
 
                hotelReservation.Should().NotBeNull();
                hotelReservation.Should().BeOfType<HotelReservation>();
            }
        }
 
        [Fact]
        public async Task Update_HotelReservation_ReturnHotelReservationUpdated()
        {
            using (var context = new HotelReservationContext(_options))
            {
                var hotelReservation = new HotelReservation
                {
                    Id = Guid.Parse("a8c0ffe5-6015-4ff5-acd1-f5e616a572d1"),
                    UserId = Guid.Parse("E48BC591-E4CD-44BF-9842-40C18FEE0F75"),
                    RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(2)
                };
 
                context.HotelReservations.Add(hotelReservation);
                context.SaveChanges();
            }
 
            using (var context = new HotelReservationContext(_options))
            {
                var hotelReservation = new HotelReservation
                {
                    Id = Guid.Parse("a8c0ffe5-6015-4ff5-acd1-f5e616a572d1"),
                    UserId = Guid.Parse("E48BC591-E4CD-44BF-9842-40C18FEE0F75"),
                    RoomId = Guid.Parse("18C6A659-31CB-4072-8455-A70267FDFA13"),
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(3)
                };
 
                var hotelReservationRepository = new HotelReservationRepository(context);
                var hotelReservationUpdated = await hotelReservationRepository.Update(hotelReservation);
 
                hotelReservationUpdated.Should().NotBeNull();
                hotelReservationUpdated.Should().BeOfType<HotelReservation>();
            }
        }
    }
}
 