using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The IOrderDetailRepository interface defines the contract for the OrderDetail repository.
    /// It provides methods to interact with the OrderDetail data in the database.
    /// </summary>
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        /// <summary>
        /// Updates the specified OrderDetail entity in the database.
        /// </summary>
        /// <param name="entity">The OrderDetail entity to be updated.</param>
        void Update(OrderDetail entity);
    }
}
