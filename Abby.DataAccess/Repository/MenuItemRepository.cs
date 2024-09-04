using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
namespace Abby.DataAccess.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly AppDbContext _context;
        public MenuItemRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(MenuItem entity)
        {
            var objFromDb = _context.MenuItems.FirstOrDefault(x => x.Id == entity.Id);
            objFromDb.Name = entity.Name;
            objFromDb.Description = entity.Description;
            objFromDb.Price = entity.Price;
            objFromDb.CategoryId = entity.CategoryId;
            objFromDb.FoodTypeId = entity.FoodTypeId;
            objFromDb.ImageUrl = entity.ImageUrl;
        }
    }
}
