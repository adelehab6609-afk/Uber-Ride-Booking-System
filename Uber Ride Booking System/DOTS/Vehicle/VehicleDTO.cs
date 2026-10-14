using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Uber_Ride_Booking_System.DOTS.Vehicle
{
    public class VehicleDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        [MaxLength(50, ErrorMessage = "Model cannot exceed 50 characters.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Plate number is required.")]
        [MaxLength(20, ErrorMessage = "Plate number cannot exceed 20 characters.")]
        public string PlateNumber { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }

        [Required]
        public int DriverId { get; set; }
    }  
    public class CreateVehicleDTO
    {

        [Required(ErrorMessage = "Model is required.")]
        [MaxLength(50, ErrorMessage = "Model cannot exceed 50 characters.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Plate number is required.")]
        [MaxLength(20, ErrorMessage = "Plate number cannot exceed 20 characters.")]
        public string PlateNumber { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }

        [Required]
        public int DriverId { get; set; }
    }
    public class UpdateVehicleDTO
    {

        [Required(ErrorMessage = "Model is required.")]
        [MaxLength(50, ErrorMessage = "Model cannot exceed 50 characters.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Plate number is required.")]
        [MaxLength(20, ErrorMessage = "Plate number cannot exceed 20 characters.")]
        public string PlateNumber { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }

        [Required]
        public int DriverId { get; set; }
    }
}
