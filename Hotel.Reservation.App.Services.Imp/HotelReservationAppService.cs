using AutoMapper;
using Hotel.Reservation.App.Messages.Common;
using Hotel.Reservation.App.Messages.Request;
using Hotel.Reservation.App.Messages.Response;
using Hotel.Reservation.Models;
using Hotel.Reservation.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Hotel.Reservation.App.Services.Imp
{
    public class HotelReservationAppService : IHotelReservationAppService
    {
        private readonly IHotelReservationService _hotelReservationService;
        private readonly IHotelRoomAppService _hotelRoomAppService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private HotelReservationAppResponse _hotelReservationAppResponse;

        public HotelReservationAppService(IHotelReservationService hotelReservationService, IHotelRoomAppService hotelRoomAppService, IMapper mapper, ILogger<HotelReservationAppService> logger, HotelReservationAppResponse hotelReservationAppResponse)
        {
            _hotelReservationService = hotelReservationService;
            _hotelRoomAppService = hotelRoomAppService;
            _mapper = mapper;
            _logger = logger;
            _hotelReservationAppResponse = hotelReservationAppResponse;
        }

        public async Task<HotelReservationAppResponse> Delete(Guid id)
        {
            HotelReservation hotelReservation = null;

            try
            {
                hotelReservation = await _hotelReservationService.Get(id);

                if (hotelReservation != null)
                {
                    await _hotelReservationService.Delete(id);

                    await _hotelRoomAppService.UpdateAvailability(hotelReservation.RoomId, true);

                    return await HotelReservationResponse(hotelReservation, ApplicationMessages.ReservationCanceled, false);
                }

                return await HotelReservationResponse(hotelReservation, ApplicationMessages.ReservationNotFound, false);

            }
            catch (Exception ex)
            {
                _logger.LogError(ApplicationMessages.ApplicationError, ex);

                return await HotelReservationResponse(hotelReservation, ApplicationMessages.ApplicationError, false);
            }
        }

        public async Task<HotelReservationAppResponse> Get(Guid id)
        {
            HotelReservation hotelReservation = null;

            try
            {
                hotelReservation = await _hotelReservationService.Get(id);

                if (hotelReservation != null)
                {
                    return await HotelReservationResponse(hotelReservation, ApplicationMessages.ReservationRetrieved, true);
                }

                return await HotelReservationResponse(hotelReservation, ApplicationMessages.ReservationNotFound, false);

            }
            catch (Exception ex)
            {

                _logger.LogError(ApplicationMessages.ApplicationError, ex);

                return await HotelReservationResponse(hotelReservation, ApplicationMessages.ApplicationError, false);
            }
        }

        public async Task<HotelReservationAppResponse> GetByUserId(Guid userId)
        {
            HotelReservation hotelReservation = null;

            try
            {
                hotelReservation = await _hotelReservationService.GetByUserId(userId);

                if (hotelReservation != null)
                {
                    return await HotelReservationResponse(hotelReservation, ApplicationMessages.ReservationRetrieved, true);
                }

                return await HotelReservationResponse(hotelReservation, ApplicationMessages.ReservationNotFound, false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ApplicationMessages.ApplicationError, ex);

                return await HotelReservationResponse(hotelReservation, ApplicationMessages.ApplicationError, false);
            }
        }

        public async Task<HotelReservationAppResponse> Patch(HotelReservationAppRequest hotelReservationAppRequest)
        {
            if (hotelReservationAppRequest != null && hotelReservationAppRequest.ValidateDates())
            {
                var hotelReservationAppRequestToHotelReservation = _mapper.Map<HotelReservationAppRequest, HotelReservation>(hotelReservationAppRequest);

                return await HotelReservationResponse(hotelReservationAppRequestToHotelReservation, ApplicationMessages.DateError, false);
            }
            else
            {
                HotelReservation hotelReservation = null;

                try
                {
                    var hotelReservationMapped = _mapper.Map<HotelReservationAppRequest, HotelReservation>(hotelReservationAppRequest);

                    hotelReservation = await _hotelReservationService.Get(hotelReservationMapped.Id);

                    if (hotelReservation != null)
                    {
                        var hotelReservationUpdated = await _hotelReservationService.Patch(hotelReservationMapped);

                        return await HotelReservationResponse(hotelReservationUpdated, ApplicationMessages.ReservationUpdated, true);
                    }

                    return await HotelReservationResponse(hotelReservation, ApplicationMessages.ReservationNotFound, false);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ApplicationMessages.ApplicationError, ex);

                    return await HotelReservationResponse(hotelReservation, ApplicationMessages.ApplicationError, false);
                }
            }
        }

        public async Task<HotelReservationAppResponse> Post(HotelReservationAppRequest hotelReservationAppRequest)
        {
            if (hotelReservationAppRequest != null && hotelReservationAppRequest.ValidateDates())
            {
                var hotelReservationAppRequestToHotelReservation = _mapper.Map<HotelReservationAppRequest, HotelReservation>(hotelReservationAppRequest);

                return await HotelReservationResponse(hotelReservationAppRequestToHotelReservation, ApplicationMessages.DateError, false);
            }
            else
            {
                HotelReservation hotelReservation = null;

                try
                {
                    // TODO: Add UnityOfWork pattern to control the transactions

                    var roomAvailability = await _hotelRoomAppService.CheckRoomAvailability(hotelReservationAppRequest.RoomId);

                    if (!roomAvailability)
                    {
                        return await HotelReservationResponse(hotelReservation, ApplicationMessages.RoomIsNotAvailable, false);
                    }

                    hotelReservation = await _hotelReservationService.Post(hotelReservationAppRequest);

                    var room = await _hotelRoomAppService.UpdateAvailability(hotelReservation.RoomId, false);

                    return await HotelReservationResponse(hotelReservation, ApplicationMessages.ReservationCompleted, true);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ApplicationMessages.ApplicationError, ex);

                    return await HotelReservationResponse(hotelReservation, ApplicationMessages.ApplicationError, false);
                }
            }

        }

        private async Task<HotelReservationAppResponse> HotelReservationResponse(HotelReservation hotelReservation, string message, bool reservationStatus)
        {
            _hotelReservationAppResponse.HotelReservation = hotelReservation;
            _hotelReservationAppResponse.Message = message;
            _hotelReservationAppResponse.ReservationStatus = reservationStatus;
            return _hotelReservationAppResponse;
        }
    }
}