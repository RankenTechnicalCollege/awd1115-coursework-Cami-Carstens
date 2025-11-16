
namespace NovelNookBookStore.Models.DataLayer
{
    public interface IRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAllASync();
        Task<IEnumerable<T>> GetAllByIdAsync<TKey>(TKey id, string propertyName, QueryOptions<T> options);
        Task<T> GetByIdAsync(int id, QueryOptions<T> options);
       
        Task AddASync(T entity);
        Task UpdateASync(T entity);
        Task DeleteAsync(int id);
    }
}
