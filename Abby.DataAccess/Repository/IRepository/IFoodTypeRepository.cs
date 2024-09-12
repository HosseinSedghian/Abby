using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The IFoodTypeRepository interface defines the contract for the FoodType repository.
    /// It provides methods to interact with the FoodType data in the database.
    /// </summary>
    public interface IFoodTypeRepository : IRepository<FoodType>
    {
        /// <summary>
        /// Updates the specified FoodType entity in the database.
        /// </summary>
        /// <param name="entity">The FoodType entity to be updated.</param>
        void Update(FoodType entity);
    }
}
