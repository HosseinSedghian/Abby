using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The IOrderHeaderRepository interface defines the contract for the OrderHeader repository.
    /// It provides methods to interact with the OrderHeader data in the database.
    /// </summary>
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        /// <summary>
        /// Updates the specified OrderHeader entity in the database.
        /// </summary>
        /// <param name="entity">The OrderHeader entity to be updated.</param>
        void Update(OrderHeader entity);
    }
}
