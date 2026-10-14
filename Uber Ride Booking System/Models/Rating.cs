using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uber_Ride_Booking_System.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Score is required.")]
        [Range(1, 5, ErrorMessage = "Score must be between 1 and 5.")]
        public int Score { get; set; }

        [MaxLength(250, ErrorMessage = "Comment cannot exceed 250 characters.")]
        public string Comment { get; set; }

        [Required]
        public int RideId { get; set; }

        [ForeignKey("RideId")]
        public Ride Ride { get; set; }
    }
}
