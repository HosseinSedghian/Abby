using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Abby.DataAccess.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        // include proprs - comma separated.
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

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entityList)
        {
            dbSet.RemoveRange(entityList);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
