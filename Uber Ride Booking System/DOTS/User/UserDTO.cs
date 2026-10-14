using System.ComponentModel.DataAnnotations;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.DOTS.User
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; } // Admin, Driver, Rider

    }
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; } // Driver, Rider, Admin
    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}