using BookinAppDio.Passenger.Dtos;
using BookingAppDio.Core.CQRS;

namespace BookinAppDio.Passenger.Application.GetPassengerById
{
    public record GetPassengerByIdQuery(long Id) : IQuery<PassengerResponseDto>;
    
}
