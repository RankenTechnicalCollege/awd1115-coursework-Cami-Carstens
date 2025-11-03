using Microsoft.EntityFrameworkCore;

namespace CustomClientValidation.Models
{
    public class RegistrationContext :DbContext

    {
        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
