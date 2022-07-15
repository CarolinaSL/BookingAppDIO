using BookingAppDio.Core.CQRS;
using BookingAppDio.Flight.API.Dtos;
using BookingAppDio.Flight.Infra.Context;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BookingAppDio.Flight.API.Application.GetFlightById
{
    public class GetFlightByIdQueryHandler : IQueryHandler<GetFlightByIdQuery, FlightResponseDto>
    {
        private readonly FlightDbContext _flightDbContext;
        private readonly IMapper _mapper;

        public GetFlightByIdQueryHandler(IMapper mapper, FlightDbContext flightDbContext)
        {
            _mapper = mapper;
            _flightDbContext = flightDbContext;
        }

        public async Task<FlightResponseDto> Handle(GetFlightByIdQuery query, CancellationToken cancellationToken)
        {

            var flight = await _flightDbContext.Flights.SingleOrDefaultAsync(x => x.Id == query.Id && !x.IsDeleted, cancellationToken);

            if (flight is null)
                throw new NotImplementedException();

            return _mapper.Map<FlightResponseDto>(flight);
        }
    }
}
