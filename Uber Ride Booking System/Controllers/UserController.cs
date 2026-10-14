//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Uber_Ride_Booking_System.DOTS.User;
//using Uber_Ride_Booking_System.Models;
//using Uber_Ride_Booking_System.Repos.Interfaces;
//using Uber_Ride_Booking_System.Services;

//namespace Uber_Ride_Booking_System.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly IUinitOfWork _userRepository; // مفترض أنك قمت بعمل Repository للـ Users
//        private readonly ITokenService _tokenService;     // خدمة لتوليد الـ JWT Token

//        public UserController(IUserRepository userRepository, ITokenService tokenService)
//        {
//            _userRepository = userRepository;
//            _tokenService = tokenService;
//        }

//        // 1. POST /api/users/auth/register (أو يمكنك وضعها في AuthController)
//        [HttpPost("auth/register")]
//        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
//        {
//            // التحقق من عدم وجود الإيميل مسبقاً وتشفير كلمة المرور
//            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
//            if (existingUser != null)
//                return BadRequest(new { message = "Email is already in use." });

//            var user = new User
//            {
//                FullName = dto.FullName,
//                Email = dto.Email,
//                Phone = dto.Phone,
//                Role = dto.Role,
//                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password) // تشفير كلمة المرور
//            };

//            await _userRepository.AddAsync(user);
//            await _userRepository.SaveChangesAsync();

//            var userDto = new UserDto
//            {
//                Id = user.Id,
//                FullName = user.FullName,
//                Email = user.Email,
//                Phone = user.Phone,
//                Role = user.Role
//            };

//            return StatusCode(201, userDto);
//        }

//        // 2. POST /api/users/auth/login
//        [HttpPost("auth/login")]
//        public async Task<IActionResult> Login([FromBody] LoginDto dto)
//        {
//            var user = await _userRepository.GetByEmailAsync(dto.Email);
//            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
//            {
//                return Unauthorized(new { message = "Invalid email or password." });
//            }

//            // توليد JWT Token وتضمين الـ Claims (Id, Email, Role)
//            var token = _tokenService.CreateToken(user);

//            return Ok(new { Token = token });
//        }

//        // 3. GET /api/users/drivers (متاح فقط للـ Admin)
//        [HttpGet("drivers")]
//        [Authorize(Roles = "Admin")]
//        public async Task<IActionResult> GetDrivers()
//        {
//            var drivers = await _userRepository.GetUsersByRoleAsync("Driver");

//            var driverDtos = drivers.Select(d => new UserDto
//            {
//                Id = d.Id,
//                FullName = d.FullName,
//                Email = d.Email,
//                Phone = d.Phone,
//                Role = d.Role
//            }).ToList();

//            return Ok(driverDtos);
//        }
//    }
//}
