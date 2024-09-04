using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
namespace Abby.DataAccess.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly AppDbContext _context;
        public FoodTypeRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(FoodType entity)
        {
            _context.Update(entity);
        }
    }
}
