using BookingAppDio.Flight.Domain.Seats;
using Mapster;

namespace BookingAppDio.Flight.API.Dtos.Mappings
{
    public class SeatMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Seat, SeatResponseDto>();
        }
    }
}
