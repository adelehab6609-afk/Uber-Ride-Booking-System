using Uber_Ride_Booking_System.GenericRepository;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Repos.Interfaces
{
    public interface IRideRepository : IGenericRepository<Ride>
    {
        Task<(IEnumerable<Ride> Items, int TotalCount)> GetPagedRidesAsync(int pageNumber, int pageSize, string sortBy);
        Task<IEnumerable<Ride>> SearchByPickupAsync(string pickup);
        Task<IEnumerable<Ride>> FilterRidesAsync(string status, decimal? minFare, decimal? maxFare, string sortBy);
        Task<object> GetRideReportAsync();
    }
}
