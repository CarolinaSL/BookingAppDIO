using BookingAppDio.Bus.Contracts;
using Mapster;
using MassTransit;
using MediatR;

namespace BookinAppDio.Passenger.Application.GetPassengerById
{
    public class GetPassengerByIdConsumer : IConsumer<GetPassengerByIdRequest>
    {
        private IMediator _mediator;

        public GetPassengerByIdConsumer(IMediator mediator)
        {
            _mediator = mediator;

        }

        public async Task Consume(ConsumeContext<GetPassengerByIdRequest> context)
        {
            var query = new GetPassengerByIdQuery(context.Message.PassengerId);

            var passengerResponseDto = await _mediator.Send(query);

            var result = passengerResponseDto.Adapt<PassengerResponse>();

            await context.RespondAsync(result);

        }
    }
}
