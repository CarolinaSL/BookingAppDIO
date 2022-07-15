using BookingAppDio.Core.CQRS;
using BookingAppDio.Flight.API.Dtos;

namespace BookingAppDio.Flight.API.Application.GetFlightById
{
    public record GetFlightByIdQuery(long Id) : IQuery<FlightResponseDto>;
}
