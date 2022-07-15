using BookingAppDio.Core.CQRS;
using BookingAppDio.Flight.API.Dtos;
using BookingAppDio.Flight.Infra.Context;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BookingAppDio.Flight.API.Application.ReserveSeat
{
    public class ReserveSeatCommandHandler : ICommandHandler<ReserveSeatCommand, SeatResponseDto>
    {
        private readonly FlightDbContext _flightDbContext;
        private readonly IMapper _mapper;

        public ReserveSeatCommandHandler(IMapper mapper, FlightDbContext flightDbContext)
        {
            _mapper = mapper;
            _flightDbContext = flightDbContext;
        }

        public async Task<SeatResponseDto> Handle(ReserveSeatCommand command, CancellationToken cancellationToken)
        {

            var seat = await _flightDbContext.Seats.SingleOrDefaultAsync(x => x.SeatNumber == command.SeatNumber && x.FlightId == command.FlightId
                && !x.IsDeleted, cancellationToken);

            if (seat is null)
                throw new NotImplementedException();

            var reserveSeat = await seat.ReserveSeat(seat);

            var updatedSeat = _flightDbContext.Seats.Update(reserveSeat);

            _flightDbContext.SaveChanges();

            return _mapper.Map<SeatResponseDto>(updatedSeat.Entity);
        }
    }
}
