using AutoMapper;
using Hotel.Reservation.App.Messages.Request;
using Hotel.Reservation.App.Messages.Response;
using Hotel.Reservation.Models;

namespace Hotel.Reservation.App.Mappers
{
    public class HotelReservationMapper : Profile
    {
        public HotelReservationMapper()
        {
            CreateMap<HotelReservation, HotelReservationAppRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ReverseMap();

            CreateMap<HotelReservationAppResponse, HotelReservation>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.HotelReservation.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.HotelReservation.UserId))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.HotelReservation.RoomId))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.HotelReservation.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.HotelReservation.EndDate))
                .ReverseMap();
        }
    }
}