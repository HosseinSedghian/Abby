using Abby.Models;
namespace Abby.DataAccess.Repository.IRepository
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        void Update(MenuItem entity);
    }
}
