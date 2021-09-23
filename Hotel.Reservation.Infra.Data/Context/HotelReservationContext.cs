using Hotel.Reservation.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Reservation.Infra.Data.Context
{
    public class HotelReservationContext : DbContext
    {
        public HotelReservationContext(DbContextOptions<HotelReservationContext> options) : base(options)
        {
        }

        public DbSet<HotelReservation> HotelReservations { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelReservation>().ToTable("HotelReservation");
            modelBuilder.Entity<Room>().ToTable("Room");
        }
    }
}