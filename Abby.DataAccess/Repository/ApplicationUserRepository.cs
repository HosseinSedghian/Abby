using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;

namespace Abby.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly AppDbContext _context;
        public ApplicationUserRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Update(ApplicationUser entity)
        {
            _context.ApplicationUsers.Update(entity);
        }
    }
}
