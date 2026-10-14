using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.GenericRepository;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Implamentation
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetByDriverIdAsync(int driverId)
        {
            return await _context.Vehicles
                .FirstOrDefaultAsync(v => v.DriverId == driverId);
        }
    }
}
