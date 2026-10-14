using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.GenericRepository;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Implamentation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Vehicle)
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            return await _context.Users
                .Where(u => u.Role.ToLower() == role.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> SearchRidersByNameAsync(string name)
        {   
            return await _context.Users
                .Where(u => u.Role == "Rider" && u.FullName.Contains(name))
                .ToListAsync();
        }
    }
}
