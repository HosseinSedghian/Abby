using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
namespace Abby.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly AppDbContext _context;
        public ShoppingCartRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void DecrementCount(ref ShoppingCart entity, int count)
        {
            entity.Count -= count;
        }

        public void IncrementCount(ref ShoppingCart entity, int count)
        {
            entity.Count += count;
        }

        public void Update(ShoppingCart entity)
        {
            _context.ShoppingCarts.Update(entity);
        }
    }
}
