namespace HOT4.Models.Validation
{
    public class Validate
    {
        public static string CheckCustomer(AppointmentContext _context, Customer customer)
        {
            
           var checkDbCustomer = _context.Customers.FirstOrDefault(c =>
            c.Username == customer.Username || 
            c.PhoneNumber == customer.PhoneNumber);


            if(checkDbCustomer == null)
            {
                return string.Empty;
            }
            else
            {
                return $"{customer.Username} is already in the database.";
            }
        }
     
    }
}
