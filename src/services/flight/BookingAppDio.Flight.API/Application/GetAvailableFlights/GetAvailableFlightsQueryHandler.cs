using BookingAppDio.Core.CQRS;
using BookingAppDio.Flight.API.Dtos;
using BookingAppDio.Flight.Infra.Context;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BookingAppDio.Flight.API.Application.GetAvailableFlights
{
    public class GetAvailableFlightsQueryHandler : IQueryHandler<GetAvailableFlightsQuery, IEnumerable<FlightResponseDto>>
    {
        private readonly FlightDbContext _flightDbContext;
        private readonly IMapper _mapper;

        public GetAvailableFlightsQueryHandler(IMapper mapper, FlightDbContext flightDbContext)
        {
            _mapper = mapper;
            _flightDbContext = flightDbContext;
        }

        public async Task<IEnumerable<FlightResponseDto>> Handle(GetAvailableFlightsQuery query,
            CancellationToken cancellationToken)
        {

            var flight = await _flightDbContext.Flights.Where(x => !x.IsDeleted).ToListAsync(cancellationToken);

            if (!flight.Any())
                throw new NotImplementedException();

            return _mapper.Map<List<FlightResponseDto>>(flight);
        }
    }
}
