using BookingAppDio.Booking.Domain.Interfaces;
using BookingAppDio.Booking.Infra.Context;
using BookingAppDio.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BookingAppDio.Booking.Infra.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _context;

       
        public BookingRepository(BookingDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public DbConnection GetConnection() => _context.Database.GetDbConnection();

        public void Add(Domain.Models.Booking booking)
        {
            _context.Bookings.AddAsync(booking);
        }

        public async Task<Domain.Models.Booking> GetById(Guid id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public void Update(Domain.Models.Booking booking)
        {
            _context.Bookings.Update(booking);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
