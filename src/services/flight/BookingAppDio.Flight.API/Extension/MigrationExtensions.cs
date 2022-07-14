using BookingAppDio.Core.Data;
using BookingAppDio.Flight.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BookingAppDio.Flight.API.Extension
{
    public static class MigrationExtensions
    {
        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
        {
            MigrateDatabase(app.ApplicationServices);
            SeedData(app.ApplicationServices);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<FlightDbContext>();
            context.Database.Migrate();
        }

        private static void SeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var seeders = scope.ServiceProvider.GetServices<IDataSeeder>();

            foreach (var seeder in seeders)
            {
                seeder.SeedAllAsync().GetAwaiter().GetResult();
            }
        }

    }
}
