using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Data;

namespace Uber_Ride_Booking_System.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public DbSet<T> _db;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }
        public async Task AddAsync(T item)
        {
            await _db.AddRangeAsync(item);
        }

        public async Task DeleteAsync(T item)
        {
            _context.Set<T>().Remove(item);
        
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _db.ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await (_db.FindAsync(id));
        }

        public void UpdateE(T item)
        {
            _db.Update(item);
        }
    }
}
