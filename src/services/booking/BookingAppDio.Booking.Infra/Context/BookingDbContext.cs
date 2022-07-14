using BookingAppDio.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookingAppDio.Booking.Infra.Context
{
    public class BookingDbContext : DbContext, IUnitOfWork
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {

        }

        public DbSet<Domain.Models.Booking> Bookings => Set<Domain.Models.Booking>();


        public async Task<bool> Commit()
        {
            var success = await base.SaveChangesAsync() > 0;
            return success;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
