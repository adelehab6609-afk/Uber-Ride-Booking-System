using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uber_Ride_Booking_System.DOTS.Vehicle;
using Uber_Ride_Booking_System.Models;
using Uber_Ride_Booking_System.Repos.Interfaces;

namespace Uber_Ride_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUinitOfWork _unitOfWork;

        public VehicleController(IUinitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Authorize(Roles = "Driver")]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDTO dto)
        {
            var vehicle = new Vehicle
            {
                Model = dto.Model,
                PlateNumber = dto.PlateNumber,
                Color = dto.Color,
                DriverId = dto.DriverId
            };

            await _unitOfWork.Vehicles.AddAsync(vehicle);
            await _unitOfWork.SaveChangesAsync();

            var vehicleDto = new VehicleDTO
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                PlateNumber = vehicle.PlateNumber,
                Color = vehicle.Color,
                DriverId = vehicle.DriverId
            };

            return StatusCode(201, vehicleDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] UpdateVehicleDTO dto)
        {
            var vehicle = await _unitOfWork.Vehicles.GetAsync(id);
            if (vehicle == null) return NotFound();

            vehicle.Model = dto.Model;
            vehicle.PlateNumber = dto.PlateNumber;
            vehicle.Color = dto.Color;

            _unitOfWork.Vehicles.UpdateE(vehicle);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new VehicleDTO
            {
                Id = vehicle.Id,
                Model = vehicle.Model,
                PlateNumber = vehicle.PlateNumber,
                Color = vehicle.Color,
                DriverId = vehicle.DriverId
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Driver,Admin")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _unitOfWork.Vehicles.GetAsync(id);
            if (vehicle == null) return NotFound();

            await _unitOfWork.Vehicles.DeleteAsync(vehicle);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}

