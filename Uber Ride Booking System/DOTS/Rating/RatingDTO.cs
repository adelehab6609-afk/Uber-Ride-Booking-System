using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.DOTS.Rating
{
    public class RatingDTO
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

    }   
    public class CreateRatingDTO
    {

        [Required(ErrorMessage = "Score is required.")]
        [Range(1, 5, ErrorMessage = "Score must be between 1 and 5.")]
        public int Score { get; set; }

        [MaxLength(250, ErrorMessage = "Comment cannot exceed 250 characters.")]
        public string Comment { get; set; }

        [Required]
        public int RideId { get; set; }

    }

    public class UpdateRatingDTO
    {

        [Required(ErrorMessage = "Score is required.")]
        [Range(1, 5, ErrorMessage = "Score must be between 1 and 5.")]
        public int Score { get; set; }

        [MaxLength(250, ErrorMessage = "Comment cannot exceed 250 characters.")]
        public string Comment { get; set; }

        [Required]
        public int RideId { get; set; }
    }
}
