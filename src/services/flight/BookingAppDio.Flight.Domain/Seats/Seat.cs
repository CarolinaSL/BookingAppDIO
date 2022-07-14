using BookingAppDio.Core.ModelsAggregate;

namespace BookingAppDio.Flight.Domain.Seats
{
    public class Seat : Aggregate<long>
    {
        public string SeatNumber { get; private set; }
        public SeatType Type { get; private set; }
        public SeatClass Class { get; private set; }
        public long FlightId { get; private set; }


        public static Seat Create(long id, string seatNumber, SeatType type, SeatClass seatClass, long flightId)
        {
            var seat = new Seat()
            {
                Id = id,
                Class = seatClass,
                Type = type,
                SeatNumber = seatNumber,
                FlightId = flightId
            };
            return seat;
        }

        public Task<Seat> ReserveSeat(Seat seat)
        {
            seat.IsDeleted = true;
            seat.LastModified = DateTime.UtcNow;

            return Task.FromResult(this);
        }


    }
}
