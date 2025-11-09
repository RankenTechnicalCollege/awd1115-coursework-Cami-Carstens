using Microsoft.EntityFrameworkCore;

namespace ManyToManyEf.Models
{
    public class RankenContext : DbContext
    {
        public RankenContext(DbContextOptions<RankenContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    Name = "Alice Johnson",
                    FinancialAidStatus = "Approved"
                },
                new Student
                {
                    StudentId = 2,
                    Name = "Bob Smith",
                    FinancialAidStatus = "Pending"
                },
                new Student
                {
                    StudentId = 3,
                    Name = "Charlie Brown",
                    FinancialAidStatus = "Denied"
                },
                new Student
                {
                    StudentId = 4,
                    Name = "Diana Prince",
                    FinancialAidStatus = "Approved"
                });


            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    Title = "Introduction to Programming"
                },
                new Course
                {
                    CourseId = 2,
                    Title = "Database Systems"
                },
                new Course
                {
                    CourseId = 3,
                    Title = "Web Development"
                },
                new Course
                {
                    CourseId = 4,
                    Title = "Data Structures"
                });

            modelBuilder.Entity<Student>().HasMany(s => s.Courses).WithMany(c => c.Students).UsingEntity(sc => sc.HasData(
                new
                {
                    CoursesCourseId = 1,
                    StudentsStudentId = 1
                },
                new
                {
                    CoursesCourseId = 1,
                    StudentsStudentId = 2
                },
                new
                {
                    CoursesCourseId = 1,
                    StudentsStudentId = 3
                },
                new
                {
                    CoursesCourseId = 1,
                    StudentsStudentId = 4
                },
                new
                {
                    CoursesCourseId = 2,
                    StudentsStudentId = 1
                },
                new
                {
                    CoursesCourseId = 2,
                    StudentsStudentId = 2
                },
                new
                {
                    CoursesCourseId = 3,
                    StudentsStudentId = 3
                },
                new
                {
                    CoursesCourseId = 3,
                    StudentsStudentId = 4
                },
                new 
                {
                    CoursesCourseId = 4,
                     StudentsStudentId = 1
                },
                new
                {
                    CoursesCourseId = 4,
                    StudentsStudentId = 4
                },
                new
                {
                    CoursesCourseId = 4,
                    StudentsStudentId = 2
                }));

        }
    }
}
