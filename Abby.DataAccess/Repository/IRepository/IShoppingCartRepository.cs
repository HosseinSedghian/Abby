using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The IShoppingCartRepository interface defines the contract for the ShoppingCart repository.
    /// It provides methods to interact with the ShoppingCart data in the database.
    /// </summary>
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        /// <summary>
        /// Updates the specified ShoppingCart entity in the database.
        /// </summary>
        /// <param name="entity">The ShoppingCart entity to be updated.</param>
        void Update(ShoppingCart entity);

        /// <summary>
        /// Increments the count of the specified ShoppingCart entity.
        /// </summary>
        /// <param name="entity">The ShoppingCart entity whose count is to be incremented.</param>
        /// <param name="count">The count to be incremented.</param>
        void IncrementCount(ref ShoppingCart entity, int count);

        /// <summary>
        /// Decrements the count of the specified ShoppingCart entity.
        /// </summary>
        /// <param name="entity">The ShoppingCart entity whose count is to be decremented.</param>
        /// <param name="count">The count to be decremented.</param>
        void DecrementCount(ref ShoppingCart entity, int count);
    }
}
