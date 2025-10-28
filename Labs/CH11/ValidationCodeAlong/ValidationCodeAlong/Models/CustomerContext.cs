
using Azure.Identity;
using Microsoft.EntityFrameworkCore;


namespace ValidationCodeAlong.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Username = "TiniTimmy",
                    Password = "password",
                    ConfirmPassword = "password"

                });
        }
    }
}
