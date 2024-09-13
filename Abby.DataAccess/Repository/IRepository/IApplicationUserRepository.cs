using Abby.Models;

namespace Abby.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The IApplicationUserRepository interface defines the contract for the ApplicationUser repository.
    /// It provides methods to interact with the ApplicationUser data in the database.
    /// </summary>
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        /// <summary>
        /// Updates the specified ApplicationUser entity in the database.
        /// </summary>
        /// <param name="entity">The ApplicationUser entity to be updated.</param>
        void Update(ApplicationUser entity);
    }
}
