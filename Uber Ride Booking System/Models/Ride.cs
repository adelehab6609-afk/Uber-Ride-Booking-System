using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uber_Ride_Booking_System.Models
{
    public class Ride
    {
           [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Pickup location is required.")]
        [MaxLength(150, ErrorMessage = "Pickup location cannot exceed 150 characters.")]
        public string PickupLocation { get; set; }

        [Required(ErrorMessage = "Drop-off location is required.")]
        [MaxLength(150, ErrorMessage = "Drop-off location cannot exceed 150 characters.")]
        public string DropOffLocation { get; set; }

        [Required(ErrorMessage = "Fare is required.")]
        [Range(20, 5000, ErrorMessage = "Fare must be between 20 and 5000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Fare { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } // Requested, Accepted, Completed, Cancelled

        [Required]
        public int RiderId { get; set; }

        [ForeignKey("RiderId")]
        public User Rider { get; set; }

        public int? DriverId { get; set; }

        [ForeignKey("DriverId")]
        public User Driver { get; set; }

        public Payment Payment { get; set; }
        public Rating Rating { get; set; }
    }
}
