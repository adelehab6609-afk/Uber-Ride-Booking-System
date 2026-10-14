using Uber_Ride_Booking_System.GenericRepository;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Repos.Interfaces
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Task<Vehicle> GetByDriverIdAsync(int driverId);
    }
}
