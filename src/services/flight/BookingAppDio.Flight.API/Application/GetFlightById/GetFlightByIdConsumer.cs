using BookingAppDio.Bus.Contracts;
using Mapster;
using MapsterMapper;
using MassTransit;
using MediatR;

namespace BookingAppDio.Flight.API.Application.GetFlightById
{
    public class GetFlightByIdConsumer : IConsumer<Bus.Contracts.GetFlightById>
    {

        private readonly IMapper _mapper;
        private IMediator _mediator;

        public GetFlightByIdConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<Bus.Contracts.GetFlightById> context)
        {
            var query = new GetFlightByIdQuery(context.Message.FlightId);

            var flight = await _mediator.Send(query);

            var result = flight.Adapt<FlightResponse>();

            await context.RespondAsync(result);
        }
    }
}
