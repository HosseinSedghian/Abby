using Abby.Models;
namespace Abby.DataAccess.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart entity);
        void IncrementCount(ref ShoppingCart entity, int count);
        void DecrementCount(ref ShoppingCart entity, int count);
    }
}
