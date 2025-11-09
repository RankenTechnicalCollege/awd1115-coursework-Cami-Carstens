using System.ComponentModel.DataAnnotations;

namespace ManyToManyEf.Models
{
    public class Course
    {
        public Course()
        {
            Students = new List<Student>(); //initialize an empty list of students
        }
        public int CourseId { get; set;}
        [Required]
        public string Title { get; set; } = string.Empty;
        public List<Student> Students { get; set; } 

    }
}
