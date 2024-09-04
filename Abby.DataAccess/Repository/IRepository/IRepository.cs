
using System.Linq.Expressions;

namespace Abby.DataAccess.Repository.IRepository
{
    public interface IRepository<T>
        where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entityList);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null);
        void Save();
    }
}
