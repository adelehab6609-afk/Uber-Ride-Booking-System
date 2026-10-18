using AutoMapper;
using Uber_Ride_Booking_System.DOTS.User;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User , RegisterDto>().ReverseMap();
        }
    }
}
