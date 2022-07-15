using BookingAppDio.Flight.API.Application.GetAvailableFlights;
using BookingAppDio.Flight.API.Application.GetAvailableSeats;
using BookingAppDio.Flight.API.Application.GetFlightById;
using BookingAppDio.Flight.API.Application.ReserveSeat;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingAppDio.Flight.API.Controllers
{
    [Route("api/seats")]
    [ApiController]
    public class SeatsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public SeatsController(IMediator mediator)
        {

            _mediator = mediator;
        }

        // [Authorize]
        [HttpGet("{FlightId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAvailableSeats([FromRoute] GetAvailableSeatsQuery query,
      CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);

            return Ok(result);
        }

        // [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ReserveSeat([FromBody] ReserveSeatCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }


    }
}
