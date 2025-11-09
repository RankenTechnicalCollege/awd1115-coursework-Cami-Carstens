namespace ManyToManyEf.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new List<Course>();
        }
        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FinancialAidStatus { get; set; } = string.Empty;
        public List<Course> Courses { get; set; }
    }
}
