using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
    /// <summary>
    /// The FoodTypeRepository class implements the repository pattern for the FoodType entity.
    /// It provides methods to interact with the FoodType data in the database.
    /// </summary>
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the FoodTypeRepository class.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public FoodTypeRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Updates the specified FoodType entity in the database.
        /// </summary>
        /// <param name="entity">The FoodType entity to be updated.</param>
        public void Update(FoodType entity)
        {
            _context.Update(entity);
        }
    }
}
