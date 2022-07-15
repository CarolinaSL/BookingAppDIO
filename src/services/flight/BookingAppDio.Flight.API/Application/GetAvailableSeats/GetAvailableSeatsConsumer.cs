using BookingAppDio.Bus.Contracts;
using MapsterMapper;
using MassTransit;
using MediatR;

namespace BookingAppDio.Flight.API.Application.GetAvailableSeats
{
    public class GetAvailableSeatsConsumer : IConsumer<GetAvailabeSeatsbyId>
    {
        private readonly IMapper _mapper;
        private IMediator _mediator;

        public GetAvailableSeatsConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<GetAvailabeSeatsbyId> context)
        {
            var flighId = context.Message.FlightId;
            var query = new GetAvailableSeatsQuery(flighId);
            var seatList = await _mediator.Send(query);

            var message = seatList.First(); // pega o primeiro assento vazio

            await context.RespondAsync<SeatResponse>(message);
        }
    }
}
