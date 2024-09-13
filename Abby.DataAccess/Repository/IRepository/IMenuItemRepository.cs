using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The IMenuItemRepository interface defines the contract for the MenuItem repository.
    /// It provides methods to interact with the MenuItem data in the database.
    /// </summary>
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        /// <summary>
        /// Updates the specified MenuItem entity in the database.
        /// </summary>
        /// <param name="entity">The MenuItem entity to be updated.</param>
        void Update(MenuItem entity);
    }
}
