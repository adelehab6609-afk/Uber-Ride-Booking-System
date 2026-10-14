namespace Uber_Ride_Booking_System.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task AddAsync(T item);
        void UpdateE(T item);
        Task DeleteAsync(T item);
    }
}
