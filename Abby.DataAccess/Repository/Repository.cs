using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Abby.DataAccess.Repository
{
    /// <summary>
    /// The Repository class implements the repository pattern for a generic entity.
    /// It provides methods to interact with the data in the database.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> dbSet;

        /// <summary>
        /// Initializes a new instance of the Repository class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public Repository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Adds the specified entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Gets all entities from the database that match the specified filter.
        /// </summary>
        /// <param name="filter">The filter to be applied.</param>
        /// <param name="includeProperties">The properties to be included.</param>
        /// <param name="orderby">The order by clause.</param>
        /// <returns>A list of entities that match the filter.</returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (string property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return orderby == null ? query.ToList() : orderby(query).ToList();
        }

        /// <summary>
        /// Gets the first entity from the database that matches the specified filter.
        /// </summary>
        /// <param name="filter">The filter to be applied.</param>
        /// <param name="includeProperties">The properties to be included.</param>
        /// <returns>The first entity that matches the filter.</returns>
        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (string property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Removes the specified entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Removes a range of entities from the database.
        /// </summary>
        /// <param name="entityList">The list of entities to be removed.</param>
        public void RemoveRange(IEnumerable<T> entityList)
        {
            dbSet.RemoveRange(entityList);
        }

        /// <summary>
        /// Saves the changes to the database.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
