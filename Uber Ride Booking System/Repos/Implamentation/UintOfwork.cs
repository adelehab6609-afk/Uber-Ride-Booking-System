using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.Repos.Implamentation;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Implamentation
{
    public class UintOfwork : IUinitOfWork
    {
        private readonly AppDbContext _context;

        public IUserRepository Users { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }
        public IRideRepository Rides { get; private set; }
        public IPaymentRepository Payments { get; private set; }
        public IRatingRepository Ratings { get; private set; }

        public UintOfwork(AppDbContext context, IUserRepository userRepository, IVehicleRepository vehicleRepository, IRatingRepository ratingRepository, IPaymentRepository paymentRepository, IRideRepository rideRepository)
        {
            _context = context;
            Users = userRepository;
            Vehicles = vehicleRepository;
            Rides = rideRepository;
            Payments = paymentRepository;
            Ratings = ratingRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}