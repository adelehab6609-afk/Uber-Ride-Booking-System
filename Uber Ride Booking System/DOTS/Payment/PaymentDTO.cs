using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.DOTS.Payment
{
    public class PaymentDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(20, 5000, ErrorMessage = "Amount must be between 20 and 5000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Payment date is required.")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required]
        public int RideId { get; set; }

    }
    public class CreatePaymentDTO
    {

        [Required(ErrorMessage = "Amount is required.")]
        [Range(20, 5000, ErrorMessage = "Amount must be between 20 and 5000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Payment date is required.")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required]
        public int RideId { get; set; }
    }
    public class UpdatePaymentDTO
    {

        [Required(ErrorMessage = "Amount is required.")]
        [Range(20, 5000, ErrorMessage = "Amount must be between 20 and 5000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Payment method is required.")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Payment date is required.")]
        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required]
        public int RideId { get; set; }

    }
}
