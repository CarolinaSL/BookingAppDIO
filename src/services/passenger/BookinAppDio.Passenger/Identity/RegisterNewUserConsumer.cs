using BookinAppDio.Passenger.Data;
using BookingAppDio.Bus.Contracts;
using BookingAppDio.Core.Generator;
using MassTransit;

namespace BookinAppDio.Passenger.Identity
{
    public class RegisterNewUserConsumer : IConsumer<UserCreated>
    {

        private readonly PassengerDbContext _passengerDbContext;

        public RegisterNewUserConsumer(PassengerDbContext passengerDbContext)
        {
            _passengerDbContext = passengerDbContext;
        }

        public async Task Consume(ConsumeContext<UserCreated> context)
        {
            var passenger = Passengers.Models.Passenger.Create(SnowFlakeIdGenerator.NewId(), context.Message.Name, context.Message.PassportNumber);

            await _passengerDbContext.AddAsync(passenger);

            await _passengerDbContext.SaveChangesAsync();
        }
    }
}
