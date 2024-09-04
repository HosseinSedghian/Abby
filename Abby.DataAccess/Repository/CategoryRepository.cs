using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
namespace Abby.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
        }
    }
}
