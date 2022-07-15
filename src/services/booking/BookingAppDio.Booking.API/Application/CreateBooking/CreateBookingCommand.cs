using BookingAppDio.Booking_API.DTOs;
using BookingAppDio.Core.CQRS;

namespace BookingAppDio.Booking_API.Application.CreateBooking
{
    public record CreateBookingCommand(long PassengerId, long FlightId, string Description) : ICommand<CreateReservationResponseDto>
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
