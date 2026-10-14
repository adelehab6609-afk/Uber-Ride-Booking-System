using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uber_Ride_Booking_System.DOTS.Ride;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IUinitOfWork _unitOfWork;

        public RideController(IUinitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Authorize(Roles = "Rider")]
        public async Task<IActionResult> CreateRide([FromBody] CreateRideDTO dto)
        {
            var ride = new Ride
            {
                PickupLocation = dto.PickupLocation,
                DropOffLocation = dto.DropOffLocation,
                Fare = dto.Fare,
                Status = "Requested",
                RiderId = dto.RiderId
            };

            await _unitOfWork.Rides.AddAsync(ride);
            await _unitOfWork.SaveChangesAsync();

            return StatusCode(201, ride);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPagedRides([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string sortBy = "")
        {
            var (items, totalCount) = await _unitOfWork.Rides.GetPagedRidesAsync(pageNumber, pageSize, sortBy);
            return Ok(new { TotalCount = totalCount, PageNumber = pageNumber, PageSize = pageSize, Data = items });
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetRideById(int id)
        {
            var ride = await _unitOfWork.Rides.GetAsync(id);
            if (ride == null) return NotFound();
            return Ok(ride);
        }

        [HttpPatch("{id}/accept")]
        [Authorize(Roles = "Driver")]
        public async Task<IActionResult> AcceptRide(int id, [FromQuery] int driverId)
        {
            var ride = await _unitOfWork.Rides.GetAsync(id);
            if (ride == null) return NotFound();

            ride.DriverId = driverId;
            ride.Status = "Accepted";

            _unitOfWork.Rides.UpdateE(ride);
            await _unitOfWork.SaveChangesAsync();

            return Ok(ride);
        }

        [HttpPatch("{id}/complete")]
        [Authorize(Roles = "Driver")]
        public async Task<IActionResult> CompleteRide(int id)
        {
            var ride = await _unitOfWork.Rides.GetAsync(id);
            if (ride == null) return NotFound();

            ride.Status = "Completed";
            _unitOfWork.Rides.UpdateE(ride);
            await _unitOfWork.SaveChangesAsync();

            return Ok(ride);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Rider,Admin")]
        public async Task<IActionResult> DeleteRide(int id)
        {
            var ride = await _unitOfWork.Rides.GetAsync(id);
            if (ride == null) return NotFound();

            await _unitOfWork.Rides.DeleteAsync(ride);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> SearchRides([FromQuery] string pickup)
        {
            var rides = await _unitOfWork.Rides.SearchByPickupAsync(pickup);
            return Ok(rides);
        }

        [HttpGet("filter")]
        [Authorize]
        public async Task<IActionResult> FilterRides([FromQuery] string status, [FromQuery] decimal? minFare, [FromQuery] decimal? maxFare, [FromQuery] string sortBy)
        {
            var rides = await _unitOfWork.Rides.FilterRidesAsync(status, minFare, maxFare, sortBy);
            return Ok(rides);
        }

        [HttpGet("report")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetReport()
        {
            var report = await _unitOfWork.Rides.GetRideReportAsync();
            return Ok(report);
        }
    }
}
