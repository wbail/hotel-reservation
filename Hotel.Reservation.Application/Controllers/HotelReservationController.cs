using Hotel.Reservation.App.Messages.Request;
using Hotel.Reservation.App.Messages.Response;
using Hotel.Reservation.App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Hotel.Reservation.Application.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class HotelReservationController : Controller
    {
        private readonly IHotelReservationAppService _hotelReservationAppService;

        public HotelReservationController(IHotelReservationAppService hotelReservationAppService)
        {
            _hotelReservationAppService = hotelReservationAppService;
        }

        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HotelReservationAppResponse>> Delete([FromBody] Guid id)
        {
            var response = await _hotelReservationAppService.Delete(id);

            if (!response.ReservationStatus)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet("reservation-by-userid")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HotelReservationAppResponse>> GetByUserId([FromBody] Guid userId)
        {
            var response = await _hotelReservationAppService.GetByUserId(userId);

            if (response.ReservationStatus)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HotelReservationAppResponse>> Get([FromBody] Guid id)
        {
            var response = await _hotelReservationAppService.Get(id);

            if (response.ReservationStatus)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpPatch]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HotelReservationAppResponse>> Patch([FromBody] HotelReservationAppRequest hotelReservationAppRequest)
        {
            var response = await _hotelReservationAppService.Patch(hotelReservationAppRequest);

            if (response.ReservationStatus)
            {
                return Ok(response);
            }

            return NotFound(response);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HotelReservationAppResponse>> Post([FromBody] HotelReservationAppRequest hotelReservationAppRequest)
        {
            var response = await _hotelReservationAppService.Post(hotelReservationAppRequest);

            if (response.ReservationStatus)
            {
                return Created("", response);
            }

            return BadRequest(response);
        }
    }
}