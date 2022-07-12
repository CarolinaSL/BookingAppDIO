using BookingAppDio.Core.ModelsAggregate;

namespace BookingAppDio.Flight.Domain.Seats
{
    public class Seat : Aggregate<long>
    {
        public string SeatNumber { get; private set; }
        public SeatType Type { get; private set; }
        public SeatClass Class { get; private set; }
        public long FlightId { get; private set; }
    }
}
