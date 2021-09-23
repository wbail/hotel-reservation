using Hotel.Reservation.App.Messages.Response;
using Hotel.Reservation.App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hotel.Reservation.Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class HotelRoomController
    {
        private readonly IHotelRoomAppService _hotelRoomAppService;

        public HotelRoomController(IHotelRoomAppService hotelRoomAppService)
        {
            _hotelRoomAppService = hotelRoomAppService;
        }

        [HttpGet]
        public async Task<HotelRoomAppResponse> Get() => await _hotelRoomAppService.Get();
    }
}