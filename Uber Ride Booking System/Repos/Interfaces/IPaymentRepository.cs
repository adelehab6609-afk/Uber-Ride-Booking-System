using Uber_Ride_Booking_System.GenericRepository;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Repos.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<object> GetPaymentStatisticsAsync();
    }
}
