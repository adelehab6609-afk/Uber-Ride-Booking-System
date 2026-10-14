using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Data;
using Uber_Ride_Booking_System.GenericRepository;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Repos.Implamentation
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context) : base(context) { _context = context; }

        public async Task<object> GetPaymentStatisticsAsync()
        {
            var totalPayments = await _context.Payments.CountAsync();
            var totalAmount = await _context.Payments.SumAsync(p => (decimal?)p.Amount) ?? 0;
            return new { TotalTransactions = totalPayments, TotalAmountCollected = totalAmount };
        }
    }
}
