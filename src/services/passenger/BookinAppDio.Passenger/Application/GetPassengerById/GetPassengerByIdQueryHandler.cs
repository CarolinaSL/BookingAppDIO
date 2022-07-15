using BookinAppDio.Passenger.Data;
using BookinAppDio.Passenger.Dtos;
using BookingAppDio.Core.CQRS;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace BookinAppDio.Passenger.Application.GetPassengerById
{
        public class GetPassengerQueryByIdHandler : IQueryHandler<GetPassengerByIdQuery, PassengerResponseDto>
        {
            private readonly PassengerDbContext _passengerDbContext;
            private readonly IMapper _mapper;

            public GetPassengerQueryByIdHandler(IMapper mapper, PassengerDbContext passengerDbContext)
            {
                _mapper = mapper;
                _passengerDbContext = passengerDbContext;
            }

            public async Task<PassengerResponseDto> Handle(GetPassengerByIdQuery query, CancellationToken cancellationToken)
            {
                var passenger =
                    await _passengerDbContext.Passengers.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

                if (passenger is null)
                    throw new NotImplementedException();

                return _mapper.Map<PassengerResponseDto>(passenger!);
            }
        }
    
}
