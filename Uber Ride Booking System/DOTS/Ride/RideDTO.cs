using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.DOTS.Ride
{
    public class RideDTO
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
        public int? DriverId { get; set; }

    } 

    public class CreateRideDTO
    {

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
        [Required]
        public int? DriverId { get; set; }
    }  
    public class UpdateRideDTO
    {

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
        [Required]
        public int? DriverId { get; set; }
    }
}
