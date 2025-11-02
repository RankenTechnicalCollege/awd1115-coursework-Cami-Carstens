namespace HOT4.Models
{
    public class AppointmentListViewModel
    {
        public List<Appointment> Appointments { get; set; } = null!;
        public List<Customer> Customers { get; set; } = null!;

        public int CustomerId { get; set; }
    }
}
