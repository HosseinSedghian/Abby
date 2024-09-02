using Microsoft.AspNetCore.Mvc.RazorPages;
using Abby.DataAccess.Data;
using Abby.Models;

namespace Abby.Web.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<Category> _Categories;
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            _Categories = _context.Categories.ToList();
        }
    }
}
