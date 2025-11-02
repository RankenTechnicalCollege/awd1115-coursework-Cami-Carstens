using Microsoft.EntityFrameworkCore;

namespace HOT4.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
        }
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Username = "ThomasRoad123",
                    PhoneNumber = "314-495-7733"
                },
                new Customer
                {
                    CustomerId = 2,
                    Username = "JackieC999",
                    PhoneNumber = "314-299-0321"
                },
                new Customer
                {
                    CustomerId = 3,
                    Username = "DarylD4321",
                    PhoneNumber = "618-407-6555"
                },
                new Customer
                {
                    CustomerId = 4,
                    Username = "FrancisDay1",
                    PhoneNumber = "636-333-3210"
                },
                new Customer
                {
                    CustomerId = 5,
                    Username = "SandySue",
                    PhoneNumber = "314-987-6543"
                });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    AppointmentId = 1,
                    Username = "SandySue",
                    AppDate = new DateTime(2025, 12, 12),
                    AppTime = new TimeSpan(15, 00, 0),
                    PhoneNumber = "314-987-6543",
                    CustomerId = 5
                },
                new Appointment
                {
                    AppointmentId = 2,
                    Username = "JackieC999",
                    AppDate = new DateTime(2026, 2, 10),
                    AppTime = new TimeSpan(14,00,0),
                    PhoneNumber = "314-299-0321",
                    CustomerId = 2
                },
                new Appointment
                {
                    AppointmentId = 3,
                    Username = "DarylD4321",
                    AppDate = new DateTime(2026, 1, 23),
                    AppTime = new TimeSpan(13,00,0),
                    PhoneNumber = "618-407-6555",
                    CustomerId = 3
                },
                new Appointment
                {
                    AppointmentId = 4,
                    Username = "ThomasRoad123",
                    AppDate = new DateTime(2025, 11, 9),
                    AppTime = new TimeSpan(17,00,0),
                    PhoneNumber = "314-495-7733",
                    CustomerId = 1
                },
                new Appointment
                {
                    AppointmentId = 5,
                    Username = "SandySue",
                    AppDate = new DateTime(2026, 4, 16),
                    AppTime = new TimeSpan(14,00,0),
                    PhoneNumber = "314-987-6543",
                    CustomerId = 5
                },
                new Appointment
                {
                    AppointmentId = 6,
                    Username = "FrancisDay1",
                    AppDate = new DateTime(2025, 12, 8),
                    AppTime = new TimeSpan(16,00,0),
                    PhoneNumber = "636-333-3210",
                    CustomerId = 4
                });
        }

    }
}
