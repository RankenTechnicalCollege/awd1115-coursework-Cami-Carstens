using Microsoft.EntityFrameworkCore;

namespace EmployeeValidation.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options) { }

        public DbSet<Sales> Sales { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Jaclynn",
                    LastName = "Reed",
                    DOB = new DateTime(1980, 6, 23),
                    DateOfHire = new DateTime(2022, 1, 18),
                    ManagerId = 0
                },
                   new Employee
                   {
                       EmployeeId = 2,
                       FirstName = "Daniel",
                       LastName = "Davis",
                       DOB = new DateTime(1989, 11, 10),
                       DateOfHire = new DateTime(2020, 12, 19),
                       ManagerId = 1
                   },
                      new Employee
                      {
                          EmployeeId = 3,
                          FirstName = "Angela",
                          LastName = "Chavez",
                          DOB = new DateTime(1975, 7, 14),
                          DateOfHire = new DateTime(1996, 6, 6),
                          ManagerId = 1
                      },
                         new Employee
                         {
                             EmployeeId = 4,
                             FirstName = "Darius",
                             LastName = "Mayville",
                             DOB = new DateTime(1986, 8, 10),
                             DateOfHire = new DateTime(2025, 5, 7),
                             ManagerId = 0
                         });
            modelBuilder.Entity<Sales>().HasData(
                new Sales
                {
                    SalesId = 1,
                    Quarter = 1,
                    Year = 2020,
                    Amount = 35256,
                    EmployeeId = 1,

                },
                 new Sales
                 {
                     SalesId = 2,
                     Quarter = 3,
                     Year = 2021,
                     Amount = 15239,
                     EmployeeId = 2,

                 },
                  new Sales
                  {
                      SalesId = 3,
                      Quarter = 4,
                      Year = 2022,
                      Amount = 22378,
                      EmployeeId = 3,

                  },
                   new Sales
                   {
                       SalesId = 4,
                       Quarter = 2,
                       Year = 2020,
                       Amount = 23589,
                       EmployeeId = 4,

                   },
                    new Sales
                    {
                        SalesId = 5,
                        Quarter = 1,
                        Year = 2023,
                        Amount = 38998,
                        EmployeeId = 1,

                    },
                     new Sales
                     {
                         SalesId = 6,
                         Quarter = 3,
                         Year = 2021,
                         Amount = 12358,
                         EmployeeId = 4,

                     });
        }
    }
}
