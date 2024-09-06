using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
namespace Abby.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly AppDbContext _context;
        public OrderDetailRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public void Update(OrderDetail entity)
        {
            _context.OrderDetails.Update(entity);
        }
    }
}
