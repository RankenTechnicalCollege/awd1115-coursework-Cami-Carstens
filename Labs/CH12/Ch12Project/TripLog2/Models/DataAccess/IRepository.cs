namespace TripLog2.Models.DataAccess
{
                  //generic type of T to allow for use of trips, activites, etc
    public interface IRepository<T> 
    {
        //interface is a bunch of method headers.
        //these are methods, but no bodies. so when you implement this interface, you have to provide the bodies
        IEnumerable<T> List(QueryOptions<T> options); //list of T objects with query options


        //2 methods. one accessed by id, one by query options
        T? Get(int id);
        T? Get(QueryOptions<T> options);

        //3 methods for inserting, updating, deleting
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();

    }
}
