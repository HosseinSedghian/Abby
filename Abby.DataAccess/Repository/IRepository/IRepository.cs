using System.Linq.Expressions;

namespace Abby.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The IRepository interface defines the contract for a generic repository.
    /// It provides methods to interact with the data in the database.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Adds the specified entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        void Add(T entity);

        /// <summary>
        /// Removes the specified entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be removed.</param>
        void Remove(T entity);

        /// <summary>
        /// Removes a range of entities from the database.
        /// </summary>
        /// <param name="entityList">The list of entities to be removed.</param>
        void RemoveRange(IEnumerable<T> entityList);

        /// <summary>
        /// Gets all entities from the database that match the specified filter.
        /// </summary>
        /// <param name="filter">The filter to be applied.</param>
        /// <param name="includeProperties">The properties to be included.</param>
        /// <param name="orderby">The order by clause.</param>
        /// <returns>A list of entities that match the filter.</returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null);

        /// <summary>
        /// Gets the first entity from the database that matches the specified filter.
        /// </summary>
        /// <param name="filter">The filter to be applied.</param>
        /// <param name="includeProperties">The properties to be included.</param>
        /// <returns>The first entity that matches the filter.</returns>
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null);

        /// <summary>
        /// Saves the changes to the database.
        /// </summary>
        void Save();
    }
}
