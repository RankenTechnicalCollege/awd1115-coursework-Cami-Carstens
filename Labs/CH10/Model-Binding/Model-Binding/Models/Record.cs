using Microsoft.AspNetCore.Mvc;

namespace Model_Binding.Models
{
    public class Record
    {
        //FREE default constructor-to overload you must code it though
        //public Record()
        //{

        //}
        //public Record(int id, string name)
        //{
        //    Id = id;
        //    Name = name;
        //}

        [FromRoute]
        public int Id { get; set; }

        [FromQuery]
        public string Name { get; set; }
    }
}
