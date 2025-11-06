using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RankenClassSchedule.Models.DomainModels;

namespace RankenClassSchedule.Models.Configuration
{
    public class TeacherConfig :IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> entity)
        {
            entity.HasData(
               new Teacher
               {
                   TeacherId = 1,
                   FirstName = "Evan",
                   LastName = "Gudmestad",

               },
                  new Teacher
                  {
                      TeacherId = 2,
                      FirstName = "Cheryl",
                      LastName = "Earls",

                  },
                   new Teacher
                   {
                       TeacherId = 3,
                       FirstName = "Tina",
                       LastName = "Womack",

                   },
               new Teacher
               {
                   TeacherId = 4,
                   FirstName = "Tim",
                   LastName = "Shumacher",

               },
               new Teacher
               {
                   TeacherId = 5,
                   FirstName = "Lenora",
                   LastName = "Moss",

               } );
        }
    
    
    }
}
