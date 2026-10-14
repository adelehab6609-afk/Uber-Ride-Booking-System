using Uber_Ride_Booking_System.Repos.Interfaces; // مكان وجود الـ Custom Repositories

namespace Uber_Ride_Booking_System.Repos.Interfaces
{
    public interface IUinitOfWork 
    {
        IUserRepository Users { get; }
        IVehicleRepository Vehicles { get; }
        IRideRepository Rides { get; }
        IPaymentRepository Payments { get; }
        IRatingRepository Ratings { get; }

        Task<int> SaveChangesAsync();
    }
}