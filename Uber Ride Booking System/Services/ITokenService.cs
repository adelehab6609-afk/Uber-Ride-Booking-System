using Uber_Ride_Booking_System.DOTS.User;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
        string Login(LoginDto loginDto);
    }
}
