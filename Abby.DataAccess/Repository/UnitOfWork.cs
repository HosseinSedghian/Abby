using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;

namespace Abby.DataAccess.Repository
{
    /// <summary>
    /// The UnitOfWork class implements the UnitOfWork pattern.
    /// It provides properties to access various repositories and a method to save changes to the database.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        public IFoodTypeRepository FoodTypeRepository { get; private set; }
        public IMenuItemRepository MenuItemRepository { get; private set; }
        public IShoppingCartRepository ShoppingCartRepository { get; private set; }
        public IOrderHeaderRepository OrderHeaderRepository { get; private set; }
        public IOrderDetailRepository OrderDetailRepository { get; private set; }
        public IApplicationUserRepository ApplicationUserRepository { get; private set; }
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The database context to be used by the UnitOfWork.</param>
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
            FoodTypeRepository = new FoodTypeRepository(_context);
            MenuItemRepository = new MenuItemRepository(_context);
            ShoppingCartRepository = new ShoppingCartRepository(_context);
            OrderHeaderRepository = new OrderHeaderRepository(_context);
            OrderDetailRepository = new OrderDetailRepository(_context);
            ApplicationUserRepository = new ApplicationUserRepository(_context);
        }

        /// <summary>
        /// Disposes the database context.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
