using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
    /// <summary>
    /// The CategoryRepository class implements the repository pattern for the Category entity.
    /// It provides methods to interact with the Category data in the database.
    /// </summary>
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the CategoryRepository class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public CategoryRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Updates the specified Category entity in the database.
        /// </summary>
        /// <param name="entity">The Category entity to be updated.</param>
        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
        }
    }
}
