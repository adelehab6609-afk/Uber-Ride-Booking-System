using Microsoft.EntityFrameworkCore;
using Uber_Ride_Booking_System.Models;

namespace Uber_Ride_Booking_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<User>()
                .HasOne(u => u.Vehicle)
                .WithOne(v => v.Driver)
                .HasForeignKey<Vehicle>(v => v.DriverId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Driver)
                .WithMany(u => u.RidesAsDriver)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Rider)
                .WithMany(u => u.RidesAsRider)
                .HasForeignKey(r => r.RiderId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Payment)
                .WithOne(p => p.Ride)
                .HasForeignKey<Payment>(p => p.RideId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Ride>()
                .HasOne(r => r.Rating)
                .WithOne(rt => rt.Ride)
                .HasForeignKey<Rating>(rt => rt.RideId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.FullName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.Phone).IsRequired();
                entity.Property(u => u.Role).IsRequired();
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(v => v.Model).IsRequired().HasMaxLength(50);
                entity.Property(v => v.PlateNumber).IsRequired().HasMaxLength(20);
                entity.Property(v => v.Color).IsRequired();
            });

            modelBuilder.Entity<Ride>(entity =>
            {
                entity.Property(r => r.PickupLocation).IsRequired().HasMaxLength(150);
                entity.Property(r => r.DropOffLocation).IsRequired().HasMaxLength(150);
                entity.Property(r => r.Fare).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(p => p.Amount).HasColumnType("decimal(18,2)");
                entity.Property(p => p.PaymentMethod).IsRequired();
                entity.Property(p => p.Status).IsRequired();
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(rt => rt.Score).IsRequired();
                entity.Property(rt => rt.Comment).HasMaxLength(250);
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "System Admin",
                    Email = "admin@uber.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEN...", 
                    Phone = "01000000001",
                    Role = "Admin"
                },
                new User
                {
                    Id = 2,
                    FullName = "Ahmed Driver",
                    Email = "driver@uber.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEN...",
                    Phone = "01011112222",
                    Role = "Driver"
                },
                new User
                {
                    Id = 3,
                    FullName = "Mohamed Rider",
                    Email = "rider@uber.com",
                    PasswordHash = "AQAAAAEAACcQAAAAEN...",
                    Phone = "01033334444",
                    Role = "Rider"
                }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    Model = "Toyota Corolla 2022",
                    PlateNumber = "ABC-1234",
                    Color = "White",
                    DriverId = 2
                }
            );

           
            modelBuilder.Entity<Ride>().HasData(
                new Ride
                {
                    Id = 1,
                    PickupLocation = "Tahrir Square, Cairo",
                    DropOffLocation = "Nasr City, Cairo",
                    Fare = 150.00m,
                    Status = "Completed",
                    RiderId = 3,
                    DriverId = 2
                }
            );

            
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1,
                    Amount = 150.00m,
                    PaymentMethod = "Credit Card",
                    PaymentDate = new DateTime(2026, 6, 1, 10, 30, 0, DateTimeKind.Utc),
                    Status = "Successful",
                    RideId = 1
                }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = 1,
                    Score = 5,
                    Comment = "Excellent and safe driver, very polite!",
                    RideId = 1
                }
            );
        }
    }
}
