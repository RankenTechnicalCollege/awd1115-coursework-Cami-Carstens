
using Microsoft.EntityFrameworkCore;

namespace TripLog2.Models.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected TripLog2Context _context { get; set; }
        private DbSet<T> dbSet { get; set; }

        public Repository(TripLog2Context ctx)
        {
            _context = ctx;
            dbSet = _context.Set<T>();
        }

        //List is Enumerable-aka you can loop over it
                                //pass a link query into the list
        public IEnumerable<T> List(QueryOptions<T> options)
        {
            //IQueryable is building query-from, where, select
            IQueryable<T> query = BuildQuery(options);
            return query.ToList();
        }

        //pass a link query into the get
        //get one element with link query.
        ///FirstOrDefault returns first element or null if none found
        public T? Get(QueryOptions<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.FirstOrDefault();
        }

        //returns an entity by its primary key
        public T? Get(int id)
        {
            //returns type of T
            return dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            //void so no return value
            //just calls add method to insert entity
            dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            //calls remove method to delete the entity
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            //calls update method to update entity
            dbSet.Update(entity);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

      
        private IQueryable<T> BuildQuery(QueryOptions<T>  options)
        {
            IQueryable<T> query = dbSet;
            foreach(string include in options.GetIncludes())
            {
                query = query.Include(include);
            }
            if (options.HasWhere)
                query = query.Where(options.Where);
            if (options.HasOrderBy)
                query = query.OrderBy(options.OrderBy);
            return query;
             
        }
    }
}
