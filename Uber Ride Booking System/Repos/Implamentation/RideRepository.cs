using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.GenericRepository;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Implamentation
{
    public class RideRepository : GenericRepository<Ride>, IRideRepository
    {
        private readonly AppDbContext _context;

        public RideRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Ride> Items, int TotalCount)> GetPagedRidesAsync(int pageNumber, int pageSize, string sortBy)
        {
            var query = _context.Rides
                .Include(r => r.Rider)
                .Include(r => r.Driver)
                .AsQueryable();

            query = sortBy?.ToLower() switch
            {
                "fare" => query.OrderBy(r => r.Fare),
                "fare_desc" => query.OrderByDescending(r => r.Fare),
                _ => query.OrderByDescending(r => r.Id)
            };

            int totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<IEnumerable<Ride>> SearchByPickupAsync(string pickup)
        {
            return await _context.Rides
                .Where(r => r.PickupLocation.Contains(pickup))
                .Include(r => r.Rider)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ride>> FilterRidesAsync(string status, decimal? minFare, decimal? maxFare, string sortBy)
        {
            var query = _context.Rides.AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(r => r.Status.ToLower() == status.ToLower());

            if (minFare.HasValue)
                query = query.Where(r => r.Fare >= minFare.Value);

            if (maxFare.HasValue)
                query = query.Where(r => r.Fare <= maxFare.Value);

            query = sortBy?.ToLower() == "fare" ? query.OrderBy(r => r.Fare) : query.OrderByDescending(r => r.Id);

            return await query.Include(r => r.Rider).Include(r => r.Driver).ToListAsync();
        }

        public async Task<object> GetRideReportAsync()
        {
            var totalRides = await _context.Rides.CountAsync();
            var completedRides = await _context.Rides.CountAsync(r => r.Status == "Completed");
            var totalRevenue = await _context.Rides.Where(r => r.Status == "Completed").SumAsync(r => (decimal?)r.Fare) ?? 0;

            return new { TotalRides = totalRides, CompletedRides = completedRides, TotalRevenue = totalRevenue };
        }
    }
}
