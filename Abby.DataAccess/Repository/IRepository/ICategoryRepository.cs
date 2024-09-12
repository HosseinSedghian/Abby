using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The ICategoryRepository interface defines the contract for the Category repository.
    /// It provides methods to interact with the Category data in the database.
    /// </summary>
    public interface ICategoryRepository : IRepository<Category>
    {
        /// <summary>
        /// Updates the specified Category entity in the database.
        /// </summary>
        /// <param name="entity">The Category entity to be updated.</param>
        void Update(Category entity);
    }
}
