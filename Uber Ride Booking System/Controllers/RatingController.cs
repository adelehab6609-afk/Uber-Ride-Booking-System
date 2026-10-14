using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uber_Ride_Booking_System.DOTS.Rating;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IUinitOfWork _unitOfWork;

        public RatingController(IUinitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Authorize(Roles = "Rider")]
        public async Task<IActionResult> CreateRating([FromBody] CreateRatingDTO dto)
        {
            var rating = new Rating
            {
                Score = dto.Score,
                Comment = dto.Comment,
                RideId = dto.RideId
            };

            await _unitOfWork.Ratings.AddAsync(rating);
            await _unitOfWork.SaveChangesAsync();

            return StatusCode(201, rating);
        }

        [HttpGet("top-drivers")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTopDrivers()
        {
            var topDrivers = await _unitOfWork.Ratings.GetTopDriversAsync();
            return Ok(topDrivers);
        }
    }
}
