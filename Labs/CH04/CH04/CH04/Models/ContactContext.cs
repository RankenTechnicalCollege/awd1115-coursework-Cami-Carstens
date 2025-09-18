using Microsoft.EntityFrameworkCore;

namespace CH04.Models;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options)
        : base(options)
    {
    }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

         modelBuilder.Entity<Category>().HasData(
        new Category { Id = 1, Name = "Family" },
        new Category { Id = 2, Name = "Friend" },
        new Category { Id = 3, Name = "Work" },
        new Category { Id = 4, Name = "Other" }
    );

        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = -1,
                CategoryId = 1,
                FirstName = "John",
                LastName = "Dally",
                Email = "DallyJ@gmail.com",
                Phone = "314-555-1234",
                Created = new DateTime(2023, 1, 1)
            },
            new Contact
            {
                Id = -2,
                CategoryId = 2,
                FirstName = "Simone",
                LastName = "Smith",
                Email = "SimoneSMITH@yahoo.com",
                Phone = "573-555-5678",
             
                Created = new DateTime(2023, 2, 15)


            },
            new Contact
            {
                Id = -3,
                CategoryId = 3,
                FirstName = "Synday",
                LastName = "Smith",
                Email = "SSmith123@gmail.com",
                Phone = "636-595-8765",
              
                Created = new DateTime(2023, 3, 10)

            },
                  new Contact
                  {
                      Id = -4,
                      CategoryId = 4,
                      FirstName = "Talia",
                      LastName = "Jones",
                      Email = "TJones78@gmail.com",
                      Phone = "314-891-5551",
                     
                      Created = new DateTime(2023, 4, 5)

                  },
            new Contact
            {
                Id = -5,
                CategoryId = 3,
                FirstName = "Thomas",
                LastName = "Jones",
                Email = "TJ9876@gmail.com",
                Phone = "314-891-4321",
             
                Created = new DateTime(2023, 4, 5)

            },
            new Contact
            {
                 Id = -6,
                CategoryId = 1,
                FirstName = "Terrance",
                LastName = "Brown",
                Email = "Brown.T_657@gmail.com",
                Phone = "314-665-6789",

                Created = new DateTime(2023, 5, 20)

            }
            );
    }
}


