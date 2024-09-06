using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
namespace Abby.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly AppDbContext _context;
        public OrderHeaderRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }
        public void Update(OrderHeader entity)
        {
            _context.OrderHeaders.Update(entity);
        }
    }
}
