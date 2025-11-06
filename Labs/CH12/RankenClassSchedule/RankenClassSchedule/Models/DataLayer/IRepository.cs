namespace RankenClassSchedule.Models.DataLayer
{
    //INTERFACE: list of methods, when you impliment interface you are forcing methods to be implimented 
    public interface IRepository<T> where T : class
    {
        //methods and method headers
        IEnumerable<T> List(QueryOptions<T> options);
        T? Get(int id);
        T? Get(QueryOptions<T> options);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
