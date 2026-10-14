using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.GenericRepository;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Implamentation
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        private readonly AppDbContext _context;
        public RatingRepository(AppDbContext context) : base(context) { _context = context; }

        public async Task<IEnumerable<object>> GetTopDriversAsync()
        {
            return await _context.Ratings
                .Include(rt => rt.Ride)
                .ThenInclude(r => r.Driver)
                .Where(rt => rt.Ride.DriverId != null)
                .GroupBy(rt => new { rt.Ride.DriverId, rt.Ride.Driver.FullName })
                .Select(g => new
                {
                    DriverId = g.Key.DriverId,
                    DriverName = g.Key.FullName,
                    AverageRating = g.Average(rt => rt.Score),
                    TotalRatings = g.Count()
                })
                .OrderByDescending(x => x.AverageRating)
                .Take(5)
                .ToListAsync();
        }
    }
}
