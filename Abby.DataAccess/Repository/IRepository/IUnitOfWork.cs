namespace Abby.DataAccess.Repository.IRepository
{
    /// <summary>
    /// The IUnitOfWork interface defines the contract for the UnitOfWork pattern.
    /// It provides properties to access various repositories and a method to save changes to the database.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the Category repository.
        /// </summary>
        ICategoryRepository CategoryRepository { get; }

        /// <summary>
        /// Gets the FoodType repository.
        /// </summary>
        IFoodTypeRepository FoodTypeRepository { get; }

        /// <summary>
        /// Gets the MenuItem repository.
        /// </summary>
        IMenuItemRepository MenuItemRepository { get; }

        /// <summary>
        /// Gets the ShoppingCart repository.
        /// </summary>
        IShoppingCartRepository ShoppingCartRepository { get; }

        /// <summary>
        /// Gets the OrderHeader repository.
        /// </summary>
        IOrderHeaderRepository OrderHeaderRepository { get; }

        /// <summary>
        /// Gets the OrderDetail repository.
        /// </summary>
        IOrderDetailRepository OrderDetailRepository { get; }

        /// <summary>
        /// Gets the ApplicationUser repository.
        /// </summary>
        IApplicationUserRepository ApplicationUserRepository { get; }
    }
}
